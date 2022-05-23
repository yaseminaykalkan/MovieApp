using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Data
{
    public class MovieAppDbContext : IdentityDbContext<User,UserRole,int>
    {
        public MovieAppDbContext(DbContextOptions<MovieAppDbContext> options)
            : base(options)
        { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            //modelBuilder.Entity<User>().HasKey(x => x.Id);
            //modelBuilder.Entity<User>().Property(x => x.UserName).HasMaxLength(50).IsRequired();

            modelBuilder.Entity<Movie>().HasKey(x => x.Id);
            modelBuilder.Entity<Movie>().Property(x => x.Name).HasMaxLength(60);

            modelBuilder.Entity<Movie>()
                .HasIndex(x => x.Name);
           
            modelBuilder.Entity<Movie>()
            .HasOne<User>(x => x.User)
            .WithMany(x => x.Movies)
            .HasForeignKey(x => x.UserId);

        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
