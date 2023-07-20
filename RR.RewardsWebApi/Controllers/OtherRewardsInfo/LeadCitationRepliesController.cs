using Microsoft.AspNetCore.Mvc;
using RR.DataBaseConnect;
using RR.Models.OtherRewardsInfo;
using RR.Services;
using RR.Services.RequestClasses;

namespace RR.RewardsWebApi.Controllers.OtherRewardsInfo
{
    [Route("api/[controller]")]
    [ApiController]
    /* [Authorize(Roles = "Admin,Moderator,Lead")]*/
    public class LeadCitationRepliesController:ControllerBase
    {
        public OtherRewardsServices OtherRewardsServices;
        public LeadCitationRepliesController(DataBaseAccess dataBaseAccess)
        {
            OtherRewardsServices = new OtherRewardsServices(dataBaseAccess);
        }

        [HttpPost]

        public async Task<ActionResult<LeadCitationReplies>> AddReply(RequestLeadCitationReplies tempreplies)
        {
            var result = await OtherRewardsServices.AddReply(tempreplies);

            return Ok(new {result.Value.ReplierId, result.Value.ReplyCitation});
        }
    }
}
