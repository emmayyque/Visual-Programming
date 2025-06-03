using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace A9aLinqToObject
{
    public class EntitiesList
    {
        public List<Department> deptList = new List<Department>
        {
            new Department()
            {
                Id = 1,
                Name = "Computer Science",
                NoOfEmployees = 50,
                Location = "Ghazali Block"
            },
            new Department()
            {
                Id = 2,
                Name = "Artificial Intelligence",
                NoOfEmployees = 45,
                Location = "Ghazali Block"
            },
            new Department()
            {
                Id = 3,
                Name = "Software Engineering",
                NoOfEmployees = 65,
                Location = "Ghazali Block"
            }
        };
    }
}