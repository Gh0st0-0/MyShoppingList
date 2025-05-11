namespace ShoppingList.Modals
{
    public class MyShopingList
    {
        public int ID { get; set; } 
        public string ItemName { get; set; }

        public double ItemQuantity {  get; set; }

        public string ListOwner {  get; set; }

        public double? ItemPrise { get; set; }
    }
}
