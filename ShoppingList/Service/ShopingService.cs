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

        public async Task<List<MyShopingList>> GetAllItemForUser(string userId)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(userId))
                throw new ArgumentException("User ID cannot be empty", nameof(userId));

            // Single query to get both owner ID and shopping lists
            var result = await (
                from owner in _dbContext.ListOwners
                where EF.Functions.Collate(owner.Name, "SQL_Latin1_General_CP1_CI_AI") == userId.ToUpper()
                join list in _dbContext.MyShopingLists on owner.Id equals list.ListOwnerId
                select list
            ).Include(i => i.shopingItemDetails).Include(i => i.Owner).ToListAsync();

            if (result.Count == 0)
                throw new ApplicationException($"No List Found for this User {userId}");

            return result;
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
