namespace ShoppingList.Modals
{
    public class ShoppingItemDetail
    {
        public int Id { get; set; }
        public string? ItemDescription { get; set; }
        public DateTime ItemExpiryDate { get; set; }
        public double? itemMRP { get; set; }
        
        // ForigenKey
        public int ShopingListId { get; set; }
    }
}
