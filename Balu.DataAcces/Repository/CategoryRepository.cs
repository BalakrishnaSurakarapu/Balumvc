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
    public class CategoryRepository: Repository<Category>, ICategoryRepositiry
    {
        private AplicationDbcontext _db;
        public CategoryRepository(AplicationDbcontext db) : base(db)
        {
            _db = db;
        }
           public void Update(Category obj)
        {
            _db.Update(obj);
        }    
        //    public void Save()
        //{
        //    _db.SaveChanges();
        //}
        
    }
}
