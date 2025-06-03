using System.ComponentModel.DataAnnotations;

namespace MVCEFCodeFirst.Models.AddModels
{
    public class AddStudent
    {
        [Required(ErrorMessage = "Name cannot be empty")]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Gender { get; set; }
    }
}
