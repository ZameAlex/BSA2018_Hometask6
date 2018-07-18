using DAL.Models;
using DAL.Repository;
using System.Collections.Generic;
using System.Linq;
using BSA2018_Hometask4.DAL.DbContext;
using System;

public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : DAL.Models.Entity
{
    //implement interface

    protected readonly AirportContext DbContext;

    public BaseRepository(AirportContext dbContext)
    {
        DbContext = dbContext;
    }

    public virtual int Create(TEntity entity)
    {
        DbContext.SetOf<TEntity>().Add(entity);
        DbContext.SaveChanges();
        return entity.Id;
    }

    public virtual void Delete(TEntity entity)
    {
        DbContext.SetOf<TEntity>().Remove(entity);
        DbContext.SaveChanges();
    }

    public virtual void Delete(int id)
    {
        DbContext.SetOf<TEntity>().Remove(DbContext.SetOf<TEntity>().SingleOrDefault(x=>x.Id==id));
        DbContext.SaveChanges();
    }

    public virtual System.Collections.Generic.List<TEntity> Get()
    {
       return DbContext.SetOf<TEntity>().ToList();
    }

    public virtual TEntity Get(int id)
    {
        return DbContext.SetOf<TEntity>().Where(x => x.Id == id).FirstOrDefault();
    }

    public virtual void Update(TEntity entity, int id)
    {
        DbContext.SaveChanges();
    }
}