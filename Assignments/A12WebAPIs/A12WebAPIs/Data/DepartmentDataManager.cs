using A12WebAPIs.Models;
using A12WebAPIs.Models.Entities;
using A12WebAPIs.Repository;

namespace A12WebAPIs.Data
{
    public class DepartmentDataManager : IDataRepository<Department>
    {
        private readonly ApplicationDbContext db;
        public DepartmentDataManager(ApplicationDbContext _db)
        {
            db = _db;
        }
        public void Add(Department entity)
        {
            db.Departments.Add(entity);
            db.SaveChanges();
        }

        public void Delete(Department entity)
        {
            db.Remove(entity);
            db.SaveChanges();
        }

        public IEnumerable<Department> GetAll()
        {
            var departments = db.Departments.ToList();
            return departments;
        }

        public Department GetById(int id)
        {
            var deptFromDb = db.Departments.SingleOrDefault(x => x.Id == id);
            return deptFromDb;
        }

        public void Update(Department dbEntity, Department entity)
        {
            dbEntity.Name = entity.Name;
            dbEntity.NoOfEmployees = entity.NoOfEmployees;
            dbEntity.Location = entity.Location;
            db.SaveChanges();
        }
    }
}
