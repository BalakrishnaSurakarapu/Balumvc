
using Balu.DataAcces.Data;
using Balu.DataAcces.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Balu.DataAcces.Repository;
using Microsoft.AspNetCore.Identity;
public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddDbContext<AplicationDbcontext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        builder.Services.AddScoped<ICategoryRepositiry, CategoryRepository>();
        builder.Services.AddScoped<IProductRepository,ProductRepository>();
        builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
       // builder.Services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<AplicationDbcontext>();
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();
      //  app.UseAuthentication();
        app.MapControllerRoute(
            name: "default",
            pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}