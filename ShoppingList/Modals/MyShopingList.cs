namespace ShoppingList.Modals
{
    public class MyShopingList
    {
        public int ID { get; set; } 
        public string ItemName { get; set; }

        public double ItemQuantity {  get; set; }

        public string ListOwner {  get; set; }

        /// <summary>
        ///  Purchase price after tax and discounts
        /// </summary>
        public double? ItemPrise { get; set; } 

        // ForigenKey
        public ShoppingItemDetail? shopingItemDetails { get; set; }
    }
}
