using Microsoft.AspNetCore.Mvc;
using Logic;
using System.Text.Json;
using Microsoft.VisualBasic;
using Org.BouncyCastle.Utilities;

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
        [Route("Update")]
        public Loadout Get(int itemid, int addon1id, int addon2id)
        {
            Item item = Calculator.Items.Find(i => i.id == itemid);
            Addon addon1 = Calculator.Addons.Find(a => a.id == addon1id);
            Addon addon2 = Calculator.Addons.Find(a => a.id == addon2id);
            Loadout loadout = new Loadout();
            loadout.Item = item;
            loadout.Addons[0] = addon1 != null ? addon1 : new Addon(new Interface.AddonDTO());
            loadout.Addons[1] = addon2 != null ? addon2 : new Addon(new Interface.AddonDTO());
            loadout.Update();
            return loadout;
        }

        [HttpGet]
        [Route("GetLongestDuration/{itemid:int}")]
        public Loadout Get(int itemid)
        {
            Loadout loadout = Calculator.GetLongestDuration(itemid);
            loadout.Update();
            return loadout;
        }

        [HttpGet]
        [Route("GetLongestDuration")]
        public Loadout Get(string type)
        {
            Interface.Type type1 = (Interface.Type)Convert.ToInt16(type);
            Loadout loadout = Calculator.GetLongestDuration(type1);
            loadout.Update();
            return loadout;
        }

        [HttpGet]
        [Route("GetToolboxTimesave/{itemid:int}")]
        public Loadout GetTimeSaved(int itemid)
        {
            Loadout loadout = Calculator.GetMostTimeSaved(itemid);
            loadout.Update();
            return loadout;
        }

        [HttpGet]
        [Route("GetToolboxTimesave")]
        public Loadout GetTimeSaved(string type)
        {
            Interface.Type type1 = (Interface.Type)Convert.ToInt16(type);
            Loadout loadout = Calculator.GetMostTimeSaved(type1);
            loadout.Update();
            return loadout;
        }
    }
}