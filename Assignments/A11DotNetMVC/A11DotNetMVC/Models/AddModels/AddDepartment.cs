using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace A11DotNetMVC.Models.AddModels
{
    public class AddDepartment
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name cannot be blank!!!")]
        [DisplayName("Department Name")]
        public String Name { get; set; }
        [Required(ErrorMessage = "No of Employees cannot be empty!!!")]
        [DisplayName("No. of Employees")]
        public int NoOfEmployees { get; set; }
        [Required(ErrorMessage = "Location of department cannot be blank!!!")]
        [DisplayName("Department's Location")]
        public String Location { get; set; }
    }
}
