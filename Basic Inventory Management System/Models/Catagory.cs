using System.ComponentModel.DataAnnotations;

namespace Basic_Inventory_Management_System.Models
{
    public class Catagory
    {
        public int id { set; get; }
        [Display(Name = "Catagory Name ")]
        [Required(ErrorMessage = "Catagory name  is required")]
      
        public string name { set; get; }

        [Display(Name="Catagory description")]
        public string Description { get; set; }
        public List <Product> ?  product { set; get; }
    }
}
