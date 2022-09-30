namespace DEVinCer.Domain.Interfaces.Repository;

public interface IBaseRepository <TEntity, Tkey> where TEntity : class
{
    void Update(TEntity entity);
    void Delete(TEntity entity);
    void Insert(TEntity entity);
    IQueryable<TEntity> ListAll();
    TEntity GetById(Tkey id);

}
