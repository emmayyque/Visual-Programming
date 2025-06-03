namespace WebAPI_Exam_.Repository
{
    public interface IDataRepository<TEntity>
    {
        public IEnumerable<TEntity> GetAll();
        public TEntity GetById(int id);
        public void Add(TEntity entity);
        public void Update(TEntity dbEntity, TEntity entity);
        public void Delete(TEntity entity);
    }
}
