using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;

namespace DAL.Repository
{
    public interface IRepository<TEntity> where TEntity:Entity
    {
        List<TEntity> Get();

        TEntity Get(int id);

        int Create(TEntity entity);

        void Update(TEntity entity, int id);

        void Delete(TEntity entity);

        void Delete(int id);
    }
}
