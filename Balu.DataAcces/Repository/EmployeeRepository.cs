using Balu.DataAcces.Repository.IRepository;
using Balu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Balu.DataAcces.Data;

namespace Balu.DataAcces.Repository
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        private AplicationDbcontext _db;
        public EmployeeRepository(AplicationDbcontext db) : base(db)
        {
            _db = db;
        }
        public void Update(Employee obj)
        {
            _db.Update(obj);
        }
    }
}
