using Microsoft.AspNetCore.Mvc;
using AzureMySQLWebAPI.Data;
using AzureMySQLWebAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureMySQLWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly ItemRepository _repository;

        public ItemsController(ItemRepository repository)
        {
            _repository = repository;
        }

        // GET: api/items
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> GetItems()
        {
            var items = await _repository.GetAllItemsAsync();
            return Ok(items);
        }

        // GET: api/items/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetItem(int id)
        {
            var item = await _repository.GetItemByIdAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        // POST: api/items
        [HttpPost]
        public async Task<ActionResult<Item>> PostItem(Item item)
        {
            int id = await _repository.AddItemAsync(item);
            item.Id = id;
            return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item);
        }

        // PUT: api/items/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItem(int id, Item item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            await _repository.UpdateItemAsync(item);

            return NoContent();
        }

        // DELETE: api/items/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            await _repository.DeleteItemAsync(id);
            return NoContent();
        }

        // POST: api/items/sp
        [HttpPost("sp")]
        public async Task<IActionResult> PostItemUsingStoredProcedure([FromBody] Item item)
        {
            await _repository.AddItemUsingStoredProcedureAsync(item);
            return CreatedAtAction("GetItem", new { id = item.Id }, item);
        }
    }
}
