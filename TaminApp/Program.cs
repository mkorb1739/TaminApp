using Microsoft.EntityFrameworkCore;
using TaminApp.Core;
using TaminApp.Models;

namespace TaminApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<TaminDB>(opt =>
                  opt.UseSqlServer(builder.Configuration.GetConnectionString("ConStr")));
            // Configure AutoMapper
            builder.Services.AddAutoMapper(typeof(Program));

            // Register UnitOfWork and Generic Repository as scoped
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
