using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RR.DataBaseConnect;
using RR.Models.OtherRewardsInfo;
using RR.Services;
using RR.Services.RequestClasses;
using System.Linq;

namespace RR.RewardsWebApi.Controllers.OtherRewardsInfo
{
    [Route("api/[controller]")]
    [ApiController]
    public class OtherRewardsResultsController : ControllerBase
    {
        private readonly DataBaseAccess dataBaseAccess;

        public OtherRewardsServices OtherRewardsServices { get; set; }
        public OtherRewardsResultsController(DataBaseAccess dataBaseAccess)
        {
            this.dataBaseAccess = dataBaseAccess;

            OtherRewardsServices = new OtherRewardsServices(dataBaseAccess);
        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<OtherRewardResults>>> Get()
        {

            return await dataBaseAccess.OtherRewardResults.Include(x => x.OtherRewards).Include(x => x.Employee).Include(x => x.Campaigns).ToListAsync();

        }
        [HttpGet]
        [Route("result/{CampaignId:int}/{Count:int}")]

        public async Task<ActionResult<IEnumerable<OtherRewardResults>>> GetResult([FromRoute] int CampaignId, int Count)
        {



            /*var results = (from l in dataBaseAccess.OtherRewardResults
                           where l.CampaignId == CampaignId
                           group l by l.NomineeId into g
                           select new
                           {
                               EmployeeId = g.First().NomineeId,
                               Stars = g.Sum(s => s.Stars) / g.ToList().Count(),
                               Award = g.First().AwardCategory
                           }).Take(Count);*/

            var arr = dataBaseAccess.OtherRewardResults.Where(x => x.Campaigns.Id == CampaignId).
                GroupBy(x => x.NomineeId).Select(s => new
                {
                    NomineeId = s.First().NomineeId,
                    Stars = s.Sum(sum => sum.Stars) / s.ToList().Count(),
                    AwardC = s.First().AwardCategory

                });
            return Ok(arr);


        }

        [HttpPost]
        [Route("Sample")]
        public async Task<ActionResult<IEnumerable<NomineesList>>>checkIfAlreadyVoted(CheckVoted checkvote)
        {
            HashSet<NomineesList> votedIds = new HashSet<NomineesList>();

            List<int> nominationsIds = new List<int>();


            await dataBaseAccess.OtherRewardResults.Include(x => x.OtherRewards).ThenInclude(x=>x.Employee)
                
                .Where(x => x.VoterId.Equals(checkvote.VoterId) && x.CampaignId == checkvote.campId).ForEachAsync(x =>
                {
                    NomineesList nomineesList = new NomineesList();
                    nomineesList.IDOfNomination = x.OtherRewards.Id;
                    nomineesList.stars = x.Stars;
                    nomineesList.voterId=x.VoterId;
                    nomineesList.NomineeId = x.NomineeId;
                    nomineesList.NominatorId = x.NominatorId;
                    nomineesList.campaignId = x.CampaignId;
                    
                    votedIds.Add(nomineesList);

                    nominationsIds.Add(x.OtherRewards.Id);
                });

            await dataBaseAccess.OtherRewards.Where(x=>x.Campaigns.Id== checkvote.campId).Include(x => x.Employee).ForEachAsync(x =>
            {
                NomineesList nomineesList = new NomineesList();
                nomineesList.IDOfNomination = x.Id;
                nomineesList.stars = 0;
                nomineesList.voterId = string.Empty;
                nomineesList.NomineeId = x.NomineeId;
                nomineesList.NominatorId = x.NominatorId;
                nomineesList.campaignId= x.CampaignId;

                if(!nominationsIds.Contains(x.Id))
                {
                    votedIds.Add (nomineesList);
                }

            });


            return Ok(votedIds);
                
        }
            


        [HttpPost]
        [Route("Vote")]
        public async Task<ActionResult<OtherRewardResults>> addVote(RequestVote requestVote)
        {
           


            ////
            ///
            OtherRewardResults otherRewardResults= await dataBaseAccess.OtherRewardResults
                .FirstOrDefaultAsync(x=>x.VoterId==requestVote.VoterId&& x.OtherRewards.Id==requestVote.idOfNomination);

            if (otherRewardResults == null)
            {
                var result = await OtherRewardsServices.addVote(requestVote);

                return Ok(new
                {
                    NomineeId = result.Value.NomineeId,
                    NominatorId = result.Value.NominatorId,
                    VoterId = result.Value.VoterId,
                    Status = "Voted"
                });
            }
            else
            {
                UpdateVote updateVote= new UpdateVote();
                updateVote.Stars = requestVote.Stars;
                updateVote.VoterId= otherRewardResults.VoterId;
                updateVote.idOfNomination = requestVote.idOfNomination;
                updateVote.voteId = otherRewardResults.Id;
                
                var result = await OtherRewardsServices.updateVote(updateVote);

                return Ok(new
                {
                    NomineeId = result.Value.NomineeId,
                    NominatorId = result.Value.NominatorId,
                    VoterId = result.Value.VoterId,
                    Status = "Updated"
                });
            }

            
        }

        [HttpPut]
        [Route("UpdateVote")]

        public async Task<ActionResult<OtherRewardResults>> updateVote(UpdateVote updateVote)
        {
            var result = await OtherRewardsServices.updateVote(updateVote);

            if(result==null)
            {
                return BadRequest("Not Valid Yaar");
            }

            return Ok(new { NomineeId=result.Value.NomineeId, NominatorId=result.Value.NominatorId,
                VoterId=result.Value.VoterId, Status = "Updated" });
        }
    }
}
