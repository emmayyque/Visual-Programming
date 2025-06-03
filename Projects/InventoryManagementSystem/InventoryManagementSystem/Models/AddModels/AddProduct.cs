using System.ComponentModel.DataAnnotations;

namespace InventoryManagementSystem.Models.AddModels
{
    public class AddProduct
    {
        [Required]
        public String? Name { get; set; }
        [Required] 
        public String? Description { get; set; }
        [Required] 
        public int Quantity { get; set; }
        [Required] 
        public int UnitPrice { get; set; }
    }
}
