using Balu.DataAcces.Data;
using Balu.DataAcces.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balu.DataAcces.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        public ICategoryRepositiry Category { get; private set; }
        public IProductRepository Product { get; private set; }
        public IEmployeeRepository Employee { get; private set; }

        private AplicationDbcontext _db;
        public UnitOfWork(AplicationDbcontext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            Product = new ProductRepository(_db);
            Employee = new EmployeeRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
