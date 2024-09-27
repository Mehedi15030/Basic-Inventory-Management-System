namespace Basic_Inventory_Management_System.Models
{
    public class PurchaseOrderItem
    {
        public int Id { get; set; }
        public int? PurchaseorderId { get; set; }
        public int? ProductId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        public Purchaseorder? PurchaseOrder { get; set; }
        public Product? Product { get; set; }
    }
}
