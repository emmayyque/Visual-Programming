using InventoryManagementSystem.Models;
using InventoryManagementSystem.Models.AddModels;
using InventoryManagementSystem.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext db;

        public UserController(ApplicationDbContext _db)
        {
            db = _db;
        }

        private bool IsUser()
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            if (UserId == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private int RoleCheck()
        {
            int? Role = HttpContext.Session.GetInt32("UserRole");
            if (Role == null)
            {
                return 0;
            }
            else
            {
                return (int)Role;
            }
        }

        // GET: UserController/Index
        public ActionResult Index()
        {
            var users = db.Users.ToList();
            return View(users);
        }

        // GET: UserController/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: UserController/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {
            try
            {
                var userFromDb = db.Users.SingleOrDefault(x => x.Username == user.Username && x.Password == user.Password);
                if (userFromDb == null)
                {
                    return View(user);
                }
                else
                {
                    HttpContext.Session.SetString("Username", userFromDb.Username);
                    HttpContext.Session.SetInt32("UserId", userFromDb.Id);
                    HttpContext.Session.SetInt32("UserRole", userFromDb.Role);

                    int Role = userFromDb.Role;

                    switch (Role)
                    {
                        case 1:
                            return RedirectToAction("Index", "Dashboard");
                            break;
                        case 2:
                            return RedirectToAction("Index", "Dashboard");
                            break;
                        case 3:
                            return RedirectToAction("Index", "Store");
                            break;
                        default:
                            return View(user);
                    }
                }

            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Signup
        public ActionResult Signup()
        {
            return View();
        }

        // POST: UserController/Signup
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Signup(AddUser addUser)
        {
            try
            {
                if (addUser.FirstName == "" || addUser.LastName == "" || addUser.Email == "" || addUser.Username == "" || addUser.Password == "")
                {
                    return View(addUser);
                }

                User user = new User()
                {
                    FirstName = addUser.FirstName,
                    LastName = addUser.LastName,
                    Email = addUser.Email,
                    Username = addUser.Username,
                    Password = addUser.Password,
                    Role = 3
                };

                db.Users.Add(user);
                db.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View(addUser);
            }
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AddUser addUser)
        {
            try
            {
                if (addUser.FirstName == "" || addUser.LastName == "" || addUser.Email == "" || addUser.Username == "" || addUser.Password == "" || addUser.Role == null)
                {
                    return View(addUser);
                }

                User user = new User()
                {
                    FirstName = addUser.FirstName,
                    LastName = addUser.LastName,
                    Email = addUser.Email,
                    Username = addUser.Username,
                    Password = addUser.Password,
                    Role = addUser.Role

                };

                db.Users.Add(user);
                db.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(addUser);
            }
        }

        // GET: UserController/Edit/6
        [HttpGet]
        public ActionResult Edit(int id)
        {
            //return View();
            try
            {
                var userFromDb = db.Users.SingleOrDefault(x => x.Id == id);
                if (userFromDb == null)
                {
                    return NotFound();
                }
                else
                {
                    return View(userFromDb);
                }
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: UserController/Edit/6
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, User user)
        {
            try
            {
                if (user.FirstName == "" || user.LastName == "" || user.Email == "" || user.Username == "" )
                {
                    return View(user);
                }

                var userFromDb = db.Users.SingleOrDefault(x => x.Id == id);
                if (userFromDb == null)
                {
                    return NotFound();
                }
                else
                {
                    userFromDb.FirstName = user.FirstName;
                    userFromDb.LastName = user.LastName;
                    userFromDb.Email = user.Email;
                    userFromDb.Username = user.Username;

                    if (user.Password != "")
                    {
                        userFromDb.Password = user.Username;
                    }

                    db.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }

            }
            catch
            {
                return View(user);
            }
        }

        // POST: UserController/MakeAdmin/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MakeAdmin(int id)
        {
            try
            {
                var userFromDb = db.Users.SingleOrDefault(x => x.Id == id);
                if (userFromDb == null)
                {
                    return NotFound();
                }
                else
                {
                    userFromDb.Role = 1;
                    db.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                return View();
            }
        }

        // POST: UserController/MakeManager/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MakeManager(int id)
        {
            try
            {
                var userFromDb = db.Users.SingleOrDefault(x => x.Id == id);
                if (userFromDb == null)
                {
                    return NotFound();
                }
                else
                {
                    userFromDb.Role = 2;
                    db.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                return View();
            }
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(User user)
        {
            try
            {
                var userFromDb = db.Users.SingleOrDefault(x => x.Id == user.Id);
                if (userFromDb == null)
                {
                    return NotFound();
                }
                else
                {
                    db.Remove(userFromDb);
                    db.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
