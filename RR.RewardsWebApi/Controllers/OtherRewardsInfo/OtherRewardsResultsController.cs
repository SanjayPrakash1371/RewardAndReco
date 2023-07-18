using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RR.DataBaseConnect;
using RR.Models.OtherRewardsInfo;

namespace RR.RewardsWebApi.Controllers.OtherRewardsInfo
{
    [Route("api/[controller]")]
    [ApiController]
    public class OtherRewardsResultsController:ControllerBase
    {
        private readonly DataBaseAccess dataBaseAccess;
        public OtherRewardsResultsController(DataBaseAccess dataBaseAccess) { this.dataBaseAccess = dataBaseAccess; }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<OtherRewardResults>>> Get()
        {

            return await dataBaseAccess.OtherRewardResults.ToListAsync();

        }
        [HttpGet]
        [Route("result/{CampaignId:int}/{Count:int}")]

        public async Task<ActionResult<IEnumerable<OtherRewardResults>>> GetResult([FromRoute] int CampaignId, int Count)
        {

           

            /*var results = (from l in dataBaseAccess.OtherRewardResults where l.CampaignId == CampaignId
                           group l by l.NomineeId into g
                           select new { EmployeeId = g.First().NomineeId, Stars = g.Sum(s => s.Stars) / g.ToList().Count(),
                               Award=g.First().AwardCategory}).Take(Count);*/

            var arr = dataBaseAccess.OtherRewardResults.Where(x => x.Campaigns.Id == CampaignId).
                GroupBy(x => x.NomineeId).Select(s => new
                {
                    NomineeId = s.First().NomineeId,
                    Stars=s.Sum(sum=>sum.Stars)/s.ToList().Count(),
                    AwardC=s.AsEnumerable().First().AwardCategory,
                 
                });
            return Ok(arr);


        }
    }
}
