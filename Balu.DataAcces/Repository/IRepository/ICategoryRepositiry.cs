
using Balu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balu.DataAcces.Repository.IRepository
{
    public interface ICategoryRepositiry:IRepository<Category>
    {
        void Update(Category obj);
       // void Save();
    }
}
