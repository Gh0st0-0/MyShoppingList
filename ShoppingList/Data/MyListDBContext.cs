using Microsoft.EntityFrameworkCore;
using ShoppingList.Modals;

namespace ShoppingList.Data
{
    public class MyListDBContext(DbContextOptions<MyListDBContext> options) : DbContext(options)
    {

        public DbSet<MyShopingList> MyShopingLists { get; set; }
        public DbSet<ShoppingItemDetail> ShoppingItemDetail { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MyShopingList>().HasData(
                new MyShopingList
                {
                    ID = 1,
                    ItemName = "Apples",
                    ItemQuantity = 2.5,
                    ListOwner = "Alice",
                    ItemPrise = 3.99
                },
                new MyShopingList
                {
                    ID = 2,
                    ItemName = "Bread",
                    ItemQuantity = 1,
                    ListOwner = "Bob",
                    ItemPrise = 2.49
                },
                new MyShopingList
                {
                    ID = 3,
                    ItemName = "Milk",
                    ItemQuantity = 1.5,
                    ListOwner = "Charlie",
                    ItemPrise = 4.25
                },
                new MyShopingList
                {
                    ID = 4,
                    ItemName = "Eggs",
                    ItemQuantity = 12,
                    ListOwner = "Alice",
                    ItemPrise = 5.99
                },
                new MyShopingList
                {
                    ID = 5,
                    ItemName = "Chicken",
                    ItemQuantity = 1.2,
                    ListOwner = "Bob",
                    ItemPrise = null // price unknown
                }
            );
        }
    }
}
