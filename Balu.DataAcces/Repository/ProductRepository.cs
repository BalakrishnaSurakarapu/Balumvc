using Balu.DataAcces.Data;
using Balu.DataAcces.Repository.IRepository;
using Balu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balu.DataAcces.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private AplicationDbcontext _db;
        public ProductRepository(AplicationDbcontext db) : base(db)
        {
            _db = db;
        }

        public void Update(Product obj)
        {
           _db.Update(obj);
        }
    }
}
