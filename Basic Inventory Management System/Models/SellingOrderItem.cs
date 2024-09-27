namespace Basic_Inventory_Management_System.Models
{
    public class SellingOrderItem
    {
        public int Id { get; set; }
        public int? SellingOrderId { get; set; }
        public int? ProductId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        public SellingOrder? SellingOrder { get; set; }
        public Product? Product { get; set; }
    }
}
