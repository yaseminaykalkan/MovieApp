using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;
using MovieApp.Data;
using MovieApp.Core.Entities;
using MovieApp.Services.Repository.Abstract;
using MovieApp.Services.Repository.EntityFramework;
using Microsoft.EntityFrameworkCore;
using MovieApp.Services.MapperProfiles;

namespace MovieApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(c => c.AddPolicy("AllowOrigin", option => option.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

            services.AddControllersWithViews().AddNewtonsoftJson(option => option.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
                .AddNewtonsoftJson(option => option.SerializerSettings.ContractResolver = new DefaultContractResolver());

           

            var connectionString = Configuration.GetConnectionString("MovieAppCon");
            services.AddDbContext<MovieAppDbContext>(options => options.UseSqlServer(connectionString));

            //services.AddIdentity<User, UserRole>(x =>
            //{

            //    x.User.AllowedUserNameCharacters = "";

            //}).AddEntityFrameworkStores<MovieAppDbContext>();

            services.AddIdentity<User, UserRole>().AddEntityFrameworkStores<MovieAppDbContext>();

            //services.AddScoped<IRepository<User, int>, UserRepo>();
            services.AddScoped<IRepository<Movie, int>, MovieRepo>();

            services.AddAutoMapper(config =>
            {
                config.AddProfile<EntityProfile>();
            });

            //var mapperConfig = new MapperConfiguration(mc =>
            //{
            //    mc.AddProfile(new EntityProfile());
            //});

            //IMapper mapper = mapperConfig.CreateMapper();
            //services.AddSingleton(mapper);

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MovieApp", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (IServiceScope scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                scope.ServiceProvider.GetService<MovieAppDbContext>().Database.Migrate();
            }

            app.UseCors(option => option.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MovieApp v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
