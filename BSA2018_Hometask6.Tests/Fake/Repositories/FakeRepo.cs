using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BSA2018_Hometask6.Tests.Fake.Repositories
{
    public class FakeRepo<TEntity> : IRepository<TEntity> where TEntity : DAL.Models.Entity
    {
        public List<TEntity> entities = new List<TEntity>();

        public FakeRepo()
        {
        }

        public virtual int Create(TEntity entity)
        {
            entity.Id = entities.Count + 1;
            entities.Add(entity);
            return entity.Id;
        }

        public virtual void Delete(TEntity entity)
        {
            entities.Remove(entity);
        }

        public virtual void Delete(int id)
        {
            entities.RemoveAt(id);
        }

        public virtual System.Collections.Generic.List<TEntity> Get()
        {
            return entities;
        }

        public virtual TEntity Get(int id)
        {
            return entities.Where(x => x.Id == id).FirstOrDefault();
        }

        public virtual void Update(TEntity entity, int id)
        {
            var temp = entities.FindIndex(x => x.Id == id);
            entities[temp] = entity;
        }

        public virtual void Update(int id, dynamic[] dynamics)
        {

        }
    }
}
