using Balu.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Balu.DataAcces.Data
{
    public class AplicationDbcontext : DbContext
    {
        public AplicationDbcontext(DbContextOptions<AplicationDbcontext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Employee> Employees { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Book",
                    DisplayOrder = 3
                }
            );
            modelBuilder.Entity<Book>().HasData(
               new Book
               {
                   Id = 1,
                   Name = "C#",
                   Orders = 4,
                   Amount = 300
               }
           );
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Title = "Foture of time",
                    Author = "Time",
                    Discription = "hello dont wast time",
                    ISBN = "dse43",
                    ListPrice = 99,
                    Price = 56,
                    Price50 = 78,
                    Price100 = 70
                }
            );
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    EmployeeId = 1,
                    EmployeeName= "Mahesh",
                },
                new Employee
                {
                    EmployeeId=2,
                    EmployeeName="Ramesh"
                }
                );
        }

    }
}
