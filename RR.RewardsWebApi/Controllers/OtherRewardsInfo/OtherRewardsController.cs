using Microsoft.AspNetCore.Mvc;
using RR.DataBaseConnect;
using RR.Models.OtherRewardsInfo;
using RR.Services;
using RR.Services.RequestClasses;

namespace RR.RewardsWebApi.Controllers.OtherRewardsInfo
{
    [Route("api/[controller]")]
    [ApiController]
    public class OtherRewardsController:ControllerBase
    {

        public OtherRewardsServices OtherRewardsServices;
        public OtherRewardsController(DataBaseAccess dataBaseAccess)
        {
            OtherRewardsServices = new OtherRewardsServices(dataBaseAccess);
        }



        // GET: api/<MonthlyRewardsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OtherRewards>>> GetRewards()
        {
            var result = await OtherRewardsServices.GetRewards();

            return Ok(result.Value);

        }


        // POST api/<MonthlyRewardsController>
        [HttpPost]
        public async Task<ActionResult<OtherRewards>> AddRewards(RequestOtherRewards requestOtherRewards)
        {
            var result = await OtherRewardsServices.AddReward(requestOtherRewards);

            return Ok(result.Value);

        }

        // PUT api/<MonthlyRewardsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
    }
}
