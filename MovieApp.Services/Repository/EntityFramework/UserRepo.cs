using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MovieApp.Services.Repository.Abstract;
using MovieApp.Core.Entities;
using MovieApp.Core.ViewModels;
using MovieApp.Data;
using System.Collections.Generic;
using System.Linq;
using System;

namespace MovieApp.Services.Repository.EntityFramework
{
    //public class UserRepo : IRepository<User, int>
    //{
    //    private readonly MovieAppDbContext _context;
    //    private readonly DbSet<User> _table;
    //    public UserRepo(MovieAppDbContext context)
    //    {
    //        _context = context;
    //        _table = _context.Set<User>();
    //    }
    //    public User GetById(int id)
    //    {
    //        return _table.Find(id);
    //    }

    //    public TKey Insert(User entity, bool isSaveLater = false)
    //    {
    //        _table.Add(entity);
    //        if (!isSaveLater)
    //            this.Save();
    //        return entity.Id;  
    //    }

    //    public int Update(User entity, bool isSaveLater = false)
    //    {
    //        _table.Update(entity);
    //        if (!isSaveLater)
    //            this.Save();
    //        return entity.Id;
    //    }

    //    public int Delete(User entity, bool isSaveLater = false)
    //    {
    //        _table.Remove(entity);
    //        if (!isSaveLater)
    //            this.Save();
    //        return entity.Id;
    //    }
    //    public List<UserViewModel> Lookup()
    //    {
    //        return this.Get()
    //            .OrderBy(x => x.UserName)
    //            .Select(x => new UserViewModel()
    //            {
    //                UserName = x.UserName,
    //                Id = x.Id
    //            })
    //            .ToList();
    //    }

    //    public int Save()
    //    {
    //        return _context.SaveChanges();
    //    }

    //    public IQueryable<User> Get(Expression<Func<User, bool>> predicate = null)
    //    {
    //        return predicate == null ? _table : _table.Where(predicate);
    //    }
    //}
}