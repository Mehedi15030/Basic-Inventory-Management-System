using System.ComponentModel.DataAnnotations;

namespace Basic_Inventory_Management_System.Models
{
    public class SellingOrder
    {
        public int Id { get; set; }

        [Display (Name=" Selling orderdate")]
        public DateTime OrderDate { get; set; }
        public double TotalAmount {  get; set; }

        public List<SellingOrderItem> Items { get; set; }
       
    }
}
