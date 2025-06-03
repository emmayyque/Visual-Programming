using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace A11DotNetMVC.Models.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public int NoOfEmployees { get; set; }
        public String Location { get; set; }
    }
}
