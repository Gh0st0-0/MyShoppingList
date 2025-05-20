using Microsoft.EntityFrameworkCore;
using ShoppingList.Data;
using ShoppingList.Modals;

namespace ShoppingList.Service
{
    public class ShopingService(MyListDBContext dbContext)
    {
        private readonly MyListDBContext _dbContext = dbContext;

        public async Task<List<MyShopingList>> GetAllListItems()
        {
            return await _dbContext.MyShopingLists
                                    .Include(i => i.shopingItemDetails)
                                    .Include(i=> i.Owner)
                                    .ToListAsync();
        }

        public async Task<MyShopingList> GetListItemByListId(int id)
        {
            var item = await _dbContext.MyShopingLists.FindAsync(id);
            if (item == null) throw new ApplicationException();
            return item;
        }

        public List<MyShopingList> GetAllItemForUser(string userId)
        {
            int idOfUserAsOwner = _dbContext.ListOwners.AsEnumerable().Where(owner => owner.Name.ToUpper() == userId.ToUpper()).Select(o=> o.Id).FirstOrDefault();
            List<MyShopingList> userList = _dbContext.MyShopingLists.AsEnumerable().Where(item => item.ListOwnerId == idOfUserAsOwner).ToList();//.Where(items => items.ListOwnerId == ;
            if (userList == null || userList.Count == 0)
                throw new ApplicationException("No List Found for this User " + userId);
            return userList;
        }

        public async Task<bool> UpdateListItem(int id,MyShopingList updateObject)
        {
            var item = await _dbContext.MyShopingLists.FindAsync(id);
            if (item == null)
            {
                throw new ApplicationException();
            }

            item.ItemName = updateObject.ItemName;
            item.ItemPrise = updateObject.ItemPrise;
            item.ItemQuantity = updateObject.ItemQuantity;
            // item.ListOwner = updateObject.ListOwner;

            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AddItemToList(MyShopingList item)
        {
            if (item == null)
                throw new ApplicationException();

            _dbContext.MyShopingLists.Add(item);
            await _dbContext.SaveChangesAsync(); // update into Database
            return true;
        }

        public async Task<bool> DeleteItemFromList(int id)
        {
            var item = await _dbContext.MyShopingLists.FindAsync(id);
            if (item == null)
            {
                throw new ApplicationException();
            }

            _dbContext.MyShopingLists.Remove(item);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
