using System.ComponentModel.DataAnnotations;

namespace Basic_Inventory_Management_System.Models
{
    public class Stock
    {
        public int id {  get; set; }

        [Display(Name = "Stock quantity ")]
        [Required(ErrorMessage = "Catagory name  is required")]
        public int Quantity { get; set; }
        public DateTime LastUpdated { get; set; }
        public int? ProductId {  get; set; }

        public Product? Product { get; set; }


    }
}
