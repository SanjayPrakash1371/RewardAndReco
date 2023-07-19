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
        public PeerToPeerServices PeerToPeerServices;

        public OtherRewardsServices OtherRewardsServices;
        private DataBaseAccess databaseAccess { get; set; }
        public CampaignsController(DataBaseAccess dataBaseAccess)
        {
            this.databaseAccess = dataBaseAccess;
            CampaignServices = new CampaignServices(dataBaseAccess);

            PeerToPeerServices = new PeerToPeerServices(dataBaseAccess);
            OtherRewardsServices = new OtherRewardsServices(dataBaseAccess);
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
        public async Task<ActionResult<Campaigns>> deleteCampaign([FromRoute] int campId)
        {
            var result= await  CampaignServices.deleteCampaign(campId);


            if(result==null)
            {
                return BadRequest("Campaign Not Present");
            }
            return Ok(result);
        }
        [HttpPost]
        [Route("PostNomination")]
        public async Task<ActionResult<Campaigns>> addNomination(RequestNomination requestNomination)
        {
            Campaigns campaigns = await databaseAccess.Campaigns.FindAsync(requestNomination.CampaignId);

            if (campaigns == null)
            {
                return BadRequest("No Campaign Exist");
            }

            if(campaigns.RewardId==1)
            {
                
                var result = await PeerToPeerServices.AddPeerToPeerNominees(requestNomination);

                return Ok(result);
            }
            else
            {

             
                var result = await OtherRewardsServices.addNomination(requestNomination);
                return Ok(result);
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