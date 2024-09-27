using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Basic_Inventory_Management_System.Models;

namespace Basic_Inventory_Management_System.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Basic_Inventory_Management_System.Models.Catagory> Catagory { get; set; } = default!;
        public DbSet<Basic_Inventory_Management_System.Models.Product> Product { get; set; } = default!;
        public DbSet<Basic_Inventory_Management_System.Models.Purchaseorder> Purchaseorder { get; set; } = default!;
        public DbSet<Basic_Inventory_Management_System.Models.PurchaseOrderItem> PurchaseOrderItem { get; set; } = default!;
        public DbSet<Basic_Inventory_Management_System.Models.SellingOrder> SellingOrder { get; set; } = default!;
        public DbSet<Basic_Inventory_Management_System.Models.SellingOrderItem> SellingOrderItem { get; set; } = default!;
        public DbSet<Basic_Inventory_Management_System.Models.Stock> Stock { get; set; } = default!;
    }
}
