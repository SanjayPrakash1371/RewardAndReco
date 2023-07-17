using Microsoft.AspNetCore.Mvc;
using RR.DataBaseConnect;
using RR.Models.PeerToPeerInfo;
using RR.Services;
using RR.Services.RequestClasses;

namespace RR.RewardsWebApi.Controllers.PeerToPeerInfo
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeerToPeerController:ControllerBase
    {
        private readonly DataBaseAccess dataBaseAccess;
        public PeerToPeerServices PeerToPeerServices;
        public PeerToPeerController(DataBaseAccess dataBaseAccess)
        {
            this.dataBaseAccess = dataBaseAccess;
            PeerToPeerServices = new PeerToPeerServices(dataBaseAccess);
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<PeerToPeer>>> GetPeerToPeer()
        {
           

            var res = await PeerToPeerServices.GetPeerToPeerAsync();

            return Ok(res);

        }

        [HttpGet]
        [Route("{NominatorId}")]

        public async Task<ActionResult<PeerToPeer>> Get([FromRoute] string NominatorId)
        {


            if (IsAvailableNominatorId(NominatorId))
            {
                var result = await PeerToPeerServices.Get(NominatorId);
                return Ok(result);
            }
            else
            {
                return BadRequest("You Have Nominated NoOne");
            }



        }



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

        private bool IsAvailableNominatorId(string NominatorId)
        {
            var res = dataBaseAccess.PeerToPeer.FirstOrDefault(x => x.NominatorId.Equals(NominatorId));
            if (res != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

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
