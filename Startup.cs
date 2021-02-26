//using BlazorAppLibrary.Data;
using BlazorAppLibrary.MappingStatistics;
using BlazorAppLibrary.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorAppLibrary
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            string connection = Configuration.GetConnectionString("myDB");
            services.AddDbContext<myDBContext>(option=>option.UseSqlServer(connection));

            //services.AddTransient(typeof(IRepository<>), typeof(Repository<>)); //??????????
            services.AddScoped<AuthorsRepository>();
            services.AddScoped<BooksRepository>();
            services.AddScoped<ImagesRepository>();
            services.AddScoped<GenresRepository>();
            services.AddScoped<UsersRepository>();
            services.AddScoped<OrdersRepository>();
            services.AddScoped<StatisticRepository>();
            //services.AddMemoryCache();
            //services.AddAutoMapper(typeof(StatisticProfile));

            services.AddRazorPages();
            services.AddServerSideBlazor();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
