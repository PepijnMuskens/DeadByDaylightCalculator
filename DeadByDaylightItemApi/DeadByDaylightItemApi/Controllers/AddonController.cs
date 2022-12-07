using Microsoft.AspNetCore.Mvc;
using Logic;
namespace DeadByDaylightaddonApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddonController : ControllerBase
    {
        private AddonContainer addonContainer;
        private readonly ILogger<AddonController> _logger;

        public AddonController(ILogger<AddonController> logger)
        {
            _logger = logger;
            addonContainer = new AddonContainer();
        }

        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<Addon> Get()
        {
            return addonContainer.GetAllAddons();
        }

        [HttpGet]
        [Route("GetAll/{type}")]
        public IEnumerable<Addon> Get(string type)
        {
            Interface.Type type1 = (Interface.Type)Convert.ToInt16(type);
            return addonContainer.GetAllAddons(type1.ToString());
        }
    }
}