using Microsoft.AspNetCore.Mvc;
using RR.DataBaseConnect;
using RR.Models.Rewards_Campaigns;
using RR.Services;
using RR.Services.RequestClasses;

namespace RR.RewardsWebApi.Controllers.Rewards_Campaigns
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampaignsController : ControllerBase
    {

        public CampaignServices CampaignServices;

        public CampaignsController(DataBaseAccess dataBaseAccess)
        {
            CampaignServices = new CampaignServices(dataBaseAccess);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Campaigns>>> GetCampaign()
        {

            var res = await CampaignServices.GetCampaign();
            return Ok(res.Value);

        }


        [HttpPost]
        public async Task<ActionResult<Campaigns>> AddCampaign(RequestCampaign requestCampaign)
        {

            var res = await CampaignServices.AddCampaign(requestCampaign);
            return Ok(res.Value);
        }
        [HttpPut]
        public async Task<ActionResult<Campaigns>> editCampaings(RequestUpdateCampaign requestUpdateCampaign)
        {
            var res = await CampaignServices.updateCampaign(requestUpdateCampaign);
            return Ok(res.Value);
        }




        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<Campaigns>> deleteCampaign([FromRoute] int id)
        {
            var result= await  CampaignServices.getCampaignById(id);


            if(result==null)
            {
                return BadRequest("Campaign Not Present da");
            }
            return Ok(result);
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
