using Microsoft.AspNetCore.Mvc;
using Logic;
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
        public IEnumerable<Item> Get()
        {
            return itemContainer.GetAllItems();
        }
    }
}