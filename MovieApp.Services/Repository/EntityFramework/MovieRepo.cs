using Microsoft.EntityFrameworkCore;
using MovieApp.Core.Entities;
using MovieApp.Data;
using MovieApp.Services.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Services.Repository.EntityFramework
{
    public class MovieRepo : RepositoryBase<Movie, int>
    {
        public MovieRepo(MovieAppDbContext context) : base(context)
        {
        }
        public override Movie GetById(int id)
        {
            return _table.Include(x => x.User).FirstOrDefault(x => x.Id == id);
        }
       
        // public override IQueryable<Movie> Get(Expression<Func<Movie, bool>> predicate = null)
        // {
        //     return base.Get(predicate).Where(x=>x.IsActive);
        // }

        // public List<MovieReportWm> MovieSaleReport(DateTime start, DateTime end)
        // {
        //     return linq.ToList();
        // }

        public IQueryable<Movie> GetActive(Expression<Func<Movie, bool>> predicate = null)
        {
            if (predicate == null)
            {
                return _table.Where(x => x.IsActive);
            }

            return _table.Where(x => x.IsActive).Where(predicate);
        }
        public override int Delete(Movie entity, bool isSaveLater = false)
        {
            entity.IsActive = false;
            return this.Update(entity, isSaveLater);
        }

        public override int Save()
        {
            //MovieLog.insert();
            Console.WriteLine("Loglandi");
            return base.Save();
        }
    }
}
