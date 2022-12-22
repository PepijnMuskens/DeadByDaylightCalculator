using Microsoft.AspNetCore.Mvc;
using Logic;
using System.Text.Json;

namespace DeadByDaylightItemApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController : ControllerBase
    {
        private ItemContainer itemContainer;
        private readonly ILogger<ItemController> _logger;

        public ItemController(ILogger<ItemController> logger)
        {
            _logger = logger;
            itemContainer = new ItemContainer();
        }

        [HttpGet]
        [Route("GetAll")]
        public string Get()
        {
            List<Item> items = Calculator.Items;
            string json = "[";
            for (int i = 0; i<items.Count; i++)
            {
                if (i != 0) json += ",";
                json += JsonSerializer.Serialize(items[i], items[i].GetType());
            }
            json += "]";

            return json;
        }

        [HttpGet]
        [Route("GetAll/{type}")]
        public string Get(string type)
        {
            List<Item> items = itemContainer.GetAllItems(type);
            string json = "[";
            for (int i = 0; i < items.Count; i++)
            {
                if (i != 0) json += ",";
                json += JsonSerializer.Serialize(items[i], items[i].GetType());
            }
            json += "]";

            return json;
        }
    }
}