using Microsoft.AspNetCore.Mvc;
using Logic;
namespace DeadByDaylightItemApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculateController : ControllerBase
    {
        private readonly ILogger<CalculateController> _logger;

        public CalculateController(ILogger<CalculateController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("GetLongestDuration/{itemid:int}")]
        public Loadout Get(int itemid)
        {
            return Calculator.GetLongestDuration(itemid);
        }

        [HttpGet]
        [Route("GetLongestDuration")]
        public Loadout Get(string type)
        {
            Interface.Type type1 = (Interface.Type)Convert.ToInt16(type);
            return Calculator.GetLongestDuration(type1);
        }
    }
}