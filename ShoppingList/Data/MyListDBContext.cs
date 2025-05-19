using Microsoft.EntityFrameworkCore;
using ShoppingList.Modals;

namespace ShoppingList.Data
{
    public class MyListDBContext(DbContextOptions<MyListDBContext> options) : DbContext(options)
    {
        /*
         Migration Steps
        1# Add-Migration Initial
        2# Update-Database
        3# Add-Migration Seeding
        4# Update-Database
        // Add new Table
        5# Add-Migration ShoppingItemDetailRelation
        6# Update-Database
        7# Add-Migration ListOwnerRelationShip // Resulting in Build failed // open for review
         */
        public DbSet<MyShopingList> MyShopingLists { get; set; }
        public DbSet<ShoppingItemDetail> ShoppingItemDetail { get; set; }
        public DbSet<ListOwner> ListOwners { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MyShopingList>().HasData(
                new MyShopingList
                {
                    ID = 1,
                    ItemName = "Apples",
                    ItemQuantity = 2.5,
                    ItemPrise = 3.99
                },
                new MyShopingList
                {
                    ID = 2,
                    ItemName = "Bread",
                    ItemQuantity = 1,
                    ItemPrise = 2.49
                },
                new MyShopingList
                {
                    ID = 3,
                    ItemName = "Milk",
                    ItemQuantity = 1.5,
                    ItemPrise = 4.25
                },
                new MyShopingList
                {
                    ID = 4,
                    ItemName = "Eggs",
                    ItemQuantity = 12,
                    ItemPrise = 5.99
                },
                new MyShopingList
                {
                    ID = 5,
                    ItemName = "Chicken",
                    ItemQuantity = 1.2,
                    ItemPrise = null // price unknown
                }
            );
        }
    }
}
