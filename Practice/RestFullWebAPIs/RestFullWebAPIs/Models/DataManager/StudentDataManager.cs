using Microsoft.AspNetCore.Http.HttpResults;
using RestFullWebAPIs.Data;
using RestFullWebAPIs.Models.Entities;
using RestFullWebAPIs.Repository;

namespace RestFullWebAPIs.Models.DataManager
{
    public class StudentDataManager : IDataRepository<Student>
    {
        private readonly ApplicationDbContext db;
        public StudentDataManager(ApplicationDbContext _db)
        {
            db = _db;
        }

        public void Add(Student entity)
        {
            db.Students.Add(entity);
            db.SaveChanges();
        }

        public void Delete(Student entity)
        {
            db.Remove(entity);
            db.SaveChanges();
        }

        public IEnumerable<Student> GetAll()
        {
            var students = db.Students.ToList();
            return students;
        }

        public Student GetById(int id)
        {
            var studentFromDb = db.Students.SingleOrDefault(x => x.Id == id);
            return studentFromDb;
        }

        public void Update(Student dbEntity, Student entity)
        {
            dbEntity.Name = entity.Name;
            dbEntity.Email = entity.Email;
            dbEntity.Phone = entity.Phone;
            dbEntity.Gender = entity.Gender;
            db.SaveChanges();
        }
    }
}
