using Hangfire;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RR.DataBaseConnect;
using RR.Models;
using RR.Models.PeerToPeerInfo;
using RR.Models.Rewards_Campaigns;
using RR.Services;
using RR.Services.RequestClasses;

namespace RR.RewardsWebApi.Controllers.Rewards_Campaigns
{
    [Route("api/[controller]")]
    [ApiController]
    /* [Authorize(Roles = "Admin,Moderator")]*/
    public class CampaignsController : ControllerBase
    {

        public CampaignServices CampaignServices;
        public PeerToPeerServices PeerToPeerServices;

        public OtherRewardsServices OtherRewardsServices;
        private DataBaseAccess databaseAccess { get; set; }

        private readonly IEmailTestService emailTestService;
        public CampaignsController(DataBaseAccess dataBaseAccess,IEmailTestService emailTestService)
        {
            this.databaseAccess = dataBaseAccess;
            CampaignServices = new CampaignServices(dataBaseAccess);

            PeerToPeerServices = new PeerToPeerServices(dataBaseAccess);
            OtherRewardsServices = new OtherRewardsServices(dataBaseAccess);

            this.emailTestService = emailTestService;


        }

        [HttpGet]
        [Route("GetCampaignsAlongWithCoubtOfNominations")]
        public async Task<ActionResult<IEnumerable<CampaignDetails>>> GetCampaign()
        {

            var res = await CampaignServices.GetCampaign();

                    

         return Ok(res.Value);
            

        }


        [HttpPost]
        public async Task<ActionResult<Campaigns>> AddCampaign(RequestCampaign requestCampaign)
        {
            // Add to database is commented . change it out

            var res = await CampaignServices.AddCampaign(requestCampaign);

            

            List<string>  mails = new List<string>();

            if(requestCampaign.RewardId ==1)
            {
                var employees = await databaseAccess.Employee.ToListAsync();

                employees.ForEach(x =>
                {
                    mails.Add(x.EmailId.ToString());
                });
            }
            else
            {
                var employees = await databaseAccess.Employee.Include(x=>x.Roles).Where(x=>x.Roles.First().IdOfRole!=4).ToListAsync();

                employees.ForEach(x =>
                {
                    mails.Add(x.EmailId.ToString());
                });

                
            }
            string[] sd= requestCampaign.StartDate.Split('-');

            int dd = Convert.ToInt32(sd[2]);

            int mm = Convert.ToInt32(sd[1]);

            int yy = Convert.ToInt32(sd[0]);

            


           var email = BackgroundJob.Schedule(() => emailTestService.SendAllMailId(mails,res.Value.CampaignName, res.Value.RewardTypes.RewardTypes), new DateTime(yy, mm, dd, 13, 00, 00));
                return Ok( new { Status="Added",mails , res.Value, sd, dd,mm,yy});
        }
        [HttpPut]
        public async Task<ActionResult<Campaigns>> editCampaings(RequestUpdateCampaign requestUpdateCampaign)
        {
            var res = await CampaignServices.updateCampaign(requestUpdateCampaign);

            if (res == null)
            {
                return BadRequest("Campaign Not FOund!🥵🥵🥵");
            }
            return Ok(res.Value);
        }




        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<Campaigns>> deleteCampaign([FromRoute] int id)
        {
            var result= await  CampaignServices.deleteCampaign(id);


            if(result==null)
            {
                return BadRequest("Campaign Not Present \U0001f975\U0001f975\U0001f975");
            }
            return Ok(new { result.Value});
        }
        [HttpPost]
        [Route("PostNomination")]
        public async Task<ActionResult<Campaigns>> addNomination(RequestNomination requestNomination)
        {
            Campaigns campaigns = await databaseAccess.Campaigns.FindAsync(requestNomination.CampaignId);

            if (campaigns == null)
            {
                return BadRequest("No Campaign Exist 😡😡😡");
            }

            if(campaigns.RewardId==1)
            {
                
                var result = await PeerToPeerServices.AddPeerToPeerNominees(requestNomination);

                return Ok(result.Value);
            }
            else
            {

             
                var result = await OtherRewardsServices.addNomination(requestNomination);
                return Ok(result.Value);
            }
        }



       /* [HttpGet]
        [Route("{campId}/{rewardId}")]
        public async Task<IActionResult> getCampaignsDetails([FromRoute] int campId, int rewardId)
        {
            var result = await CampaignServices.getCampaignDetailsByCampId(campId, rewardId);

            return Ok(result);
        }*/


    }
}
/* RequestOtherRewards requestOtherRewards = new RequestOtherRewards();
              requestOtherRewards.Citation = requestNomination.Citation;
              requestOtherRewards.AwardCategory = requestNomination.AwardCategory;

              requestOtherRewards.NomineeId = requestNomination.NomineeId;

              requestOtherRewards.NominatorId = requestNomination.NominatorId;
              requestOtherRewards.CampaignId = requestNomination.CampaignId;
        

requestOtherRewards.Citation = requestNomination.Citation;*/

/*RequestPeerToPeer requestPeerToPeer = new RequestPeerToPeer();
                requestPeerToPeer.Citation=requestNomination.Citation;
                requestPeerToPeer.AwardCategory=requestNomination.AwardCategory;

                requestPeerToPeer.NomineeId=requestNomination.NomineeId;

                requestPeerToPeer.NominatorId=requestNomination.NominatorId;
                requestPeerToPeer.CampaignId = requestNomination.CampaignId;
                requestPeerToPeer.Citation=requestPeerToPeer.Citation;*/