using Microsoft.AspNetCore.Mvc;
using RR.DataBaseConnect;
using RR.Models.PeerToPeerInfo;
using RR.Models.Rewards_Campaigns;
using RR.Services;
using RR.Services.RequestClasses;
using System.Diagnostics.Eventing.Reader;

namespace RR.RewardsWebApi.Controllers.PeerToPeerInfo
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeerToPeerController : ControllerBase
    {
        private readonly DataBaseAccess dataBaseAccess;
        public PeerToPeerServices PeerToPeerServices;
        public EmployeeServices EmployeeServices;
        public PeerToPeerController(DataBaseAccess dataBaseAccess)
        {
            PeerToPeerServices = new PeerToPeerServices(dataBaseAccess);
            EmployeeServices = new EmployeeServices(dataBaseAccess);
            this.dataBaseAccess = dataBaseAccess;
        }

        [HttpGet]
        [Route("{CampaignId:int}")]


        public async Task<ActionResult<IEnumerable<PeerToPeer>>> GetPeerToPeer([FromRoute] int CampaignId)
        {

              var res = await PeerToPeerServices.GetPeerToPeerAsync(CampaignId);

            if (res != null)
            {
                // return Ok(res);


                return Ok(res.Value.Select(x => new
                {
                    Campaigns = x.Campaigns.CampaignName,
                    RewardType = x.Campaigns.RewardTypes.RewardTypes,
                    startDate = x.Campaigns.StartDate,
                    endDate = x.Campaigns.EndDate,
                    NomainatorId = x.NominatorId,
                    NominatorName = dataBaseAccess.Employee.FirstOrDefault(e => e.EmployeeId.Equals(x.NominatorId)).Name,
                    NomineeName = x.Employee.Name,
                    NomineeId = x.NomineeId,
                    Designation = x.Employee.Designation,
                    Month = x.Month,
                    AwardCategory = x.AwardCategory,
                    Citation = x.Citation,





                }));
            }
            else
            {
                return BadRequest("No one has Nominated still...");
            }

            

          
        }


        /*public bool isAvailable(int CampaignId)
        {
            var res = dataBaseAccess.PeerToPeer.Find(CampaignId);
            if(res!= null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }*/


       /* public bool IsAvailable(int CampaignId)
        {

            var res = dataBaseAccess.PeerToPeer.FirstOrDefault(x => x.CampaignId.Equals(CampaignId));
            if (res != null)
            {
                return true;
            }
            else
            {
                return false;
            }
            // return (dataBaseAccess.PeerToPeer?.Any(x => x.CampaignId.Equals(CampaignId))).GetValueOrDefault();

        }*/


        /*
                [HttpGet]
                [Route("{NomineeId}")]

                public async Task<ActionResult<PeerToPeer>> Get([FromRoute] string NomineeId)
                {

                        var result = await PeerToPeerServices.Get(NomineeId);
                        return Ok(result);



                }
        */


        [HttpPost]

        public async Task<ActionResult<PeerToPeer>> AddPeerToPeerNominees(RequestPeerToPeer requestPeerToPeer)
        {
            if(requestPeerToPeer.NominatorId.Equals(requestPeerToPeer.NomineeId))
            {
                return Ok("You cant vote yourself ");
            }


            var res = await PeerToPeerServices.AddPeerToPeerNominees(requestPeerToPeer);
            return Ok(res);

        }

        /* public bool IsAvailableNominatorId(string NominatorId)
         {
             return (dataBaseAccess.PeerToPeer?.Any(x => x.NominatorId.Equals(NominatorId))).GetValueOrDefault();

         }*/

        [HttpPut]
        public async   Task<ActionResult<PeerToPeer>> EditNomination(RequestPeerToPeer requestPeerToPeer)
        {
            var result=await PeerToPeerServices.editNomination(requestPeerToPeer);

            if (result == null)
            {
                return BadRequest("Not nominated");
            }
            return Ok(result.Value.NominatorId+"Updated");

        }
    }
}
