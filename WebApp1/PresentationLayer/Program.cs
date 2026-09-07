using Microsoft.EntityFrameworkCore;
using WebApp1.BLogicLayer.Interfaces;
using WebApp1.BLogicLayer.Services;
using WebApp1.DAL.Database;
using Microsoft.AspNetCore.Identity;
using WebApp1.DAL.Entities;

namespace WebApp1.PresentationLayer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // new instance of AppDbContext, database settings from appsettings.json.
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("cs"));
            });

            builder.Services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
            })
.AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders();

            builder.Services.AddScoped<IDepartmentService, DepartmentService>();
            builder.Services.AddScoped<IInstructorService, InstructorService>();
            builder.Services.AddScoped<ICourseService, CourseService>();
            builder.Services.AddScoped<IStudentService, StudentService>();
            builder.Services.AddScoped<IEnrollmentService, EnrollmentService>();
            builder.Services.AddSession();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapStaticAssets();

            app.Map("/admin", admin =>
            {
                admin.Run(async context =>
                {
                    await context.Response.WriteAsync(
                        "Hello Admin");
                });
            });

            app.Map("/middleware-demo", demo =>
            {
                demo.Use(async (context, next) =>
                {
                    await context.Response.WriteAsync(
                        "before Middleware 1\n");

                    await next();

                    await context.Response.WriteAsync(
                        "after Middleware 1\n");
                });

                demo.Use(async (context, next) =>
                {
                    await context.Response.WriteAsync(
                        "before Middleware 2\n");

                    await next();

                    await context.Response.WriteAsync(
                        "after Middleware 2\n");
                });

                demo.Use(async (context, next) =>
                {
                    await context.Response.WriteAsync(
                        "before Middleware 3\n");

                    await next();

                    await context.Response.WriteAsync(
                        "after Middleware 3\n");
                });

                demo.Run(async context =>
                {
                    await context.Response.WriteAsync(
                        "Run Middleware\n");
                });
            });


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
