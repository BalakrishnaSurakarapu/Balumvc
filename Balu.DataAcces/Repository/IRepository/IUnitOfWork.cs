using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balu.DataAcces.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepositiry Category { get; }
        IProductRepository Product { get; }
        IEmployeeRepository Employee { get; }
        void Save();
    }
}
