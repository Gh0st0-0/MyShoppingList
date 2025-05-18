using System.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingList.Data;
using ShoppingList.Modals;
using ShoppingList.Service;
using ShoppingList.ServiceUtilities;

namespace ShoppingList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyListController(ShopingService service) : ControllerBase
    {
        private readonly ShopingService _service = service;

        [HttpGet]
        public async Task<ActionResult<List<MyShopingList>>> GetAllLists()
        {
            return Ok(await _service.GetAllListItems());
        }

        [HttpGet("id={id}")]
        public async Task<ActionResult<MyShopingList>> GetListItemById(int id)
        {
            try
            {
                var item = _service.GetListItemByListId(id);
                return Ok(item);
            }
            catch (ApplicationException ex)
            {
                return NotFound(ex);
            }
        }

        [HttpGet("owner={userId}")]
        public ActionResult<List<MyShopingList>> GetAllItemForUser(string userId)
        {
            try
            {
                List<MyShopingList> userList = _service.GetAllItemForUser(userId);
                return Ok(userList);
            }
            catch (ApplicationException ex)
            {
                return NotFound(ex);
            }
        }

        [HttpPost]
        public async Task<ActionResult<MyShopingList>> AddNMewListItem(MyShopingList item)
        {
            try
            {
                await _service.AddItemToList(item);
                return CreatedAtAction(nameof(GetListItemById), new { id = item.ID }, item);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("id={id}")]
        public async Task<IActionResult> UpdateListItem(int id, MyShopingList updateObject)
        {
            try
            {
                await _service.UpdateListItem(id, updateObject);
                return NoContent();
            }
            catch (ApplicationException ex)
            {
                return NotFound(ex);
            }
        }

        [HttpDelete("id={id}")]
        public async Task<IActionResult> DeleteItemFromList(int id)
        {
            try
            {
                await _service.DeleteItemFromList(id);
                return NoContent();
            }
            catch (ApplicationException ex)
            {
                return NotFound(ex);
            }
        }

        //static private List<MyShopingList> shoppingList = new List<MyShopingList>
        //{
        //    new MyShopingList
        //    {
        //        ID = 1,
        //        ItemName = "Apples",
        //        ItemQuantity = 2.5,
        //        ListOwner = "Alice",
        //        ItemPrise = 3.99
        //    },
        //    new MyShopingList
        //    {
        //        ID = 2,
        //        ItemName = "Bread",
        //        ItemQuantity = 1,
        //        ListOwner = "Bob",
        //        ItemPrise = 2.49
        //    },
        //    new MyShopingList
        //    {
        //        ID = 3,
        //        ItemName = "Milk",
        //        ItemQuantity = 1.5,
        //        ListOwner = "Charlie",
        //        ItemPrise = 4.25
        //    },
        //    new MyShopingList
        //    {
        //        ID = 4,
        //        ItemName = "Eggs",
        //        ItemQuantity = 12,
        //        ListOwner = "Alice",
        //        ItemPrise = 5.99
        //    },
        //    new MyShopingList
        //    {
        //        ID = 5,
        //        ItemName = "Chicken",
        //        ItemQuantity = 1.2,
        //        ListOwner = "Bob",
        //        ItemPrise = null // price unknown
        //    }
        //};
        //[HttpGet("id={id}")]
        //public ActionResult<MyShopingList> GetListItemById(int id)
        //{
        //    var item = shoppingList.FirstOrDefault(item => item.ID == id);
        //    if(item == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(item);
        //}

        //[HttpGet("owner={userId}")]
        //public ActionResult<List<MyShopingList>> GetAllItemForUser(string userId)
        //{
        //    List<MyShopingList> userList = shoppingList.AsEnumerable().Where(items => items.ListOwner.ToUpper() == userId.ToUpper()).ToList();
        //    if (userList == null || userList.Count == 0)
        //        return NotFound();
        //    return Ok(userList);
        //}

        //[HttpPost]
        //public ActionResult<MyShopingList> AddNMewListItem(MyShopingList item)
        //{
        //    if (item == null)
        //        return BadRequest();
        //    item.ID = shoppingList.Max(i => i.ID) + 1;
        //    shoppingList.Add(item);
        //    return CreatedAtAction(nameof(GetListItemById), new {id = item.ID},item);
        //}

        //[HttpPut("id={id}")]
        //public IActionResult UpdateListItem(int id,MyShopingList updateObject)
        //{
        //    var item = shoppingList.FirstOrDefault(i => i.ID == id);
        //    if (item == null) return NotFound();

        //    item.ItemName = updateObject.ItemName;
        //    item.ItemPrise = updateObject.ItemPrise;
        //    item.ItemQuantity = updateObject.ItemQuantity;
        //    item.ListOwner = updateObject.ListOwner;

        //    return NoContent();
        //}

        //[HttpDelete("id={id}")]
        //public IActionResult DeleteItemFromList(int id)
        //{
        //    var item = shoppingList.FirstOrDefault(i => i.ID == id);
        //    if (item == null) return NotFound();
        //    shoppingList.Remove(item);
        //    return NoContent();
        //}

    }
}
