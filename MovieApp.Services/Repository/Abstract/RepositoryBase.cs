using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MovieApp.Core.Entities.Abstracts;
using MovieApp.Data;

namespace MovieApp.Services.Repository.Abstract
{
    public abstract class RepositoryBase<TEntity, TKey> : IRepository<TEntity, TKey>
    where TEntity : BaseEntity<TKey>
    {
        protected readonly MovieAppDbContext _context;
        protected DbSet<TEntity> _table;

        protected RepositoryBase(MovieAppDbContext context)
        {
            _context = context;
            _table = _context.Set<TEntity>();
        }

        public virtual TEntity GetById(TKey id)
        {
            return _table.Find(id);
        }

        public virtual TKey Insert(TEntity entity, bool isSaveLater = false)
        {
            _table.Add(entity);
            if (!isSaveLater)
                this.Save();
            return entity.Id;
        }

        public virtual int Update(TEntity entity, bool isSaveLater = false)
        {
            _table.Update(entity);
            if (!isSaveLater)
                return this.Save();
            return 0;
        }

        public virtual int Delete(TEntity entity, bool isSaveLater = false)
        {
            _table.Update(entity);
            if (!isSaveLater)
                return this.Save();
            return 0;
        }

        public virtual int Save()
        {
            return _context.SaveChanges();
        }

        public virtual IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate = null)
        {
            return predicate == null ? _table : _table.Where(predicate);
        }
    }
}