using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCEFCodeFirst.Models;
using MVCEFCodeFirst.Models.AddModels;
using MVCEFCodeFirst.Models.Entities;

namespace MVCEFCodeFirst.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext db;
        
        // Dependency Injection
        public StudentController(ApplicationDbContext _db)
        {
            db = _db;
        }

        // GET: StudentController
        public ActionResult Index()
        {
            var Students = db.Students.ToList();
            return View(Students);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AddStudent addStudent)
        {
            try
            {
                Student student = new Student()
                {
                    Name = addStudent.Name,
                    Email = addStudent.Email,
                    Gender = addStudent.Gender
                };
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            var student = db.Students.SingleOrDefault(x => x.Id == id);
            return View(student);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Student student)
        {
            try
            {
                var dbStudent = db.Students.SingleOrDefault(x => x.Id == id);
                if (dbStudent == null)
                {
                    return View();
                }
                dbStudent.Name = student.Name;
                dbStudent.Email = student.Email;
                dbStudent.Gender = student.Gender;
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Edit));
            }
        }

        // GET: StudentController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Student student)
        {
            try
            {
                var dbStudent = db.Students.SingleOrDefault(x => x.Id == student.Id);
                if (dbStudent == null)
                {
                    return View();
                }
                db.Remove(dbStudent);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
