using System.ComponentModel.DataAnnotations;

namespace Basic_Inventory_Management_System.Models
{
    public class Product
    {
        public int id { set; get; }
        [Display(Name = "Product name")]
        [Required(ErrorMessage = "Product Name is required")]
        public string name { set; get; }

        [Display(Name = "Product Picture")]
        [Required(ErrorMessage = "Product Picture is required")]
        public string ProfilePictureURL { get; set; }

        [Display(Name = "Product description")]
        [Required(ErrorMessage = "Product description is required")]
        public string description { get; set; }

        [Display(Name = "Product price")]
        [Required(ErrorMessage = " Product Price  is required")]
        public double price { get; set; }
        [Display(Name = "Stock Product  Quantity")]
        [Required(ErrorMessage = "  Stock Product quantity is required")]
        public int StockQuantity { get; set; }



        public int? CatagoryId {  get; set; }

        public Catagory? catagory { get; set; }

        public List<Stock>? stocks { get; set; }
        public List<PurchaseOrderItem>? Items { get; set; }

        public List<SellingOrderItem>? Item { get; set; }
    }
}
