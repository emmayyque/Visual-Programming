using System.ComponentModel.DataAnnotations;

namespace MVCDotNETWebApp.Models.AddModels
{
    public class AddProduct
    {
        [Required(ErrorMessage = "Name cannot be empty")]
        public String Name { get; set; }
        [Required(ErrorMessage = "Description cannot be empty")]
        public String Description { get; set; }
        [Required(ErrorMessage = "Quantity cannot be blank")]
        public int Quantity { get; set; }
    }
}
