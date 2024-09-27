using System.ComponentModel.DataAnnotations;

namespace Basic_Inventory_Management_System.Models
{
    public class Purchaseorder
    {
        public int Id { get; set; }
        [Display(Name = " Purchase orderdate")]
        public DateTime OrderDate { get; set; }
        public double TotalAmount {  get; set; }

        public List<PurchaseOrderItem>? Items { get; set; }
       

    }
}
