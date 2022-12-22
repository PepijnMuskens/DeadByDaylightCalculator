using Microsoft.AspNetCore.Mvc;
using Logic;
using Interface;
using System.Text.Json;

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
        public string Get()
        {
            List<Addon> addons = Calculator.Addons;
            string json = "[";
            for (int i = 0; i < addons.Count; i++)
            {
                if (i != 0) json += ",";
                json += JsonSerializer.Serialize(addons[i], addons[i].GetType());
            }
            json += "]";

            return json;
        }

        [HttpGet]
        [Route("GetAll/{type}")]
        public string Get(string type)
        {
            Interface.Type type1 = (Interface.Type)Convert.ToInt16(type);
            List<Addon> addons = addonContainer.GetAllAddons(type1.ToString());
            string json = "[";
            for (int i = 0; i < addons.Count; i++)
            {
                if (i != 0) json += ",";
                json += JsonSerializer.Serialize(addons[i], addons[i].GetType());
            }
            json += "]";

            return json;
        }
    }
}