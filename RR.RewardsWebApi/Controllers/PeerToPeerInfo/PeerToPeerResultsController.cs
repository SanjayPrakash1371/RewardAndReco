using Microsoft.AspNetCore.Mvc;
using RR.DataBaseConnect;
using RR.Models.PeerToPeerInfo;

namespace RR.RewardsWebApi.Controllers.PeerToPeerInfo
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeerToPeerResultsController:ControllerBase
    {
        private readonly DataBaseAccess dataBaseAccess;
        public PeerToPeerResultsController(DataBaseAccess dataBaseAccess) { this.dataBaseAccess = dataBaseAccess; }

        [HttpGet]
        [Route("{requiredNoOfWinners}")]

        public async Task<ActionResult<IEnumerable<PeerToPeerResults>>> GetResult([FromRoute] int requiredNoOfWinners)
        {

            var arr = dataBaseAccess.PeerToPeerResults.GroupBy(p => p.NomineeId);

            var result = (from l in arr select new { Id = l.Key, CountOfNominations = l.ToList().Count() })
                .OrderByDescending(x => x.CountOfNominations).Take(requiredNoOfWinners);





            return Ok(result);


        }
    }
}
