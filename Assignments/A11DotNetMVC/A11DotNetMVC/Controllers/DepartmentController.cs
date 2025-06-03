using A11DotNetMVC.Models;
using A11DotNetMVC.Models.AddModels;
using A11DotNetMVC.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace A11DotNetMVC.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly ApplicationDbContext db;
        public DepartmentController(ApplicationDbContext _db)
        {
            db = _db;
        }
        // GET: DepartmentController
        public ActionResult Index()
        {
            var departments = db.Departments.ToList();
            return View(departments);
        }

        // GET: DepartmentController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DepartmentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AddDepartment addDepartment)
        {
            try
            {
                if (addDepartment.Name == "" || addDepartment.NoOfEmployees == 0 || addDepartment.Location == "")
                {
                    return View(addDepartment);
                }
                else
                {
                    Department department = new Department()
                    {
                        Name = addDepartment.Name,
                        NoOfEmployees = addDepartment.NoOfEmployees,
                        Location = addDepartment.Location
                    };
                    
                    db.Departments.Add(department);
                    db.SaveChanges();

                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                return View(addDepartment);
            }
        }

        // GET: DepartmentController/Edit/5
        public ActionResult Edit(int id)
        {
            var deptFromDb = db.Departments.SingleOrDefault(x => x.Id == id);
            if (deptFromDb == null)
            {
                return NotFound();
            }
            else
            {
                return View(deptFromDb);
            }
            
        }

        // POST: DepartmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Department department)
        {
            try
            {
                if (department.Name == "" || department.Location == "")
                {
                    return View(department);
                }
                else
                {
                    var deptFromDb = db.Departments.SingleOrDefault(x => x.Id == department.Id);
                    if (deptFromDb == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        deptFromDb.Name = department.Name;
                        deptFromDb.NoOfEmployees = department.NoOfEmployees;
                        deptFromDb.Location = department.Location;

                        db.SaveChanges();

                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            catch
            {
                return View(department);
            }
        }

        //// GET: DepartmentController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: DepartmentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Department department)
        {
            try
            {
                var deptFromDb = db.Departments.SingleOrDefault(x => x.Id == department.Id);
                if (deptFromDb == null)
                {
                    return NotFound();
                }
                else
                {
                    db.Remove(deptFromDb);
                    db.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
