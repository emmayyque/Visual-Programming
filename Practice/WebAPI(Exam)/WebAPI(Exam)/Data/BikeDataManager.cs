using WebAPI_Exam_.Models;
using WebAPI_Exam_.Models.Entities;
using WebAPI_Exam_.Repository;

namespace WebAPI_Exam_.Data
{
    public class BikeDataManager : IDataRepository<Bike>
    {
        private readonly ApplicationDbContext db;

        public BikeDataManager(ApplicationDbContext _db)
        {
            db = _db;
        }

        public void Add(Bike bike)
        {
            db.Bikes.Add(bike);
            db.SaveChanges();
        }

        public void Delete(Bike entity)
        {
            db.Remove(entity);
            db.SaveChanges();
        }

        public IEnumerable<Bike> GetAll()
        {
            var bikes = db.Bikes.ToList();
            return bikes;
        }

        public Bike GetById(int id)
        {
            var bikeFromDb = db.Bikes.SingleOrDefault(x => x.Id == id);
            return bikeFromDb;
        }

        public void Update(Bike dbEntity, Bike entity)
        {
            dbEntity.BikeName = entity.BikeName;
            dbEntity.Make = entity.Make;
            dbEntity.Model = entity.Model;
            db.SaveChanges();
        }
    }
}
