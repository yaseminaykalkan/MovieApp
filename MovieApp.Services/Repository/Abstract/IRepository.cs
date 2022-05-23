using System;
using System.Linq;
using System.Linq.Expressions;
using MovieApp.Core.Entities.Abstracts;

namespace MovieApp.Services.Repository.Abstract
{
    public interface IRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        TEntity GetById(TKey id);
        TKey Insert(TEntity entity, bool isSaveLater = false);
        int Update(TEntity entity, bool isSaveLater = false);
        int Delete(TEntity entity, bool isSaveLater = false);
        int Save();
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate = null);
    }
}