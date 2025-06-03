using System.ComponentModel.DataAnnotations;

namespace DotNetCoreWebAPIs.Models.Entities
{
    public class Product
    {
        
        public int Id { get; set; }
        [Required(ErrorMessage = "Name cannot be empty")]
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
    }
}
