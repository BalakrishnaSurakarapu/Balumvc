﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Balu.DataAcces.Repository.IRepository
{
    public interface IRepository<T>where T:class
    {
        //T-Category
        IEnumerable<T> GetAll();
        T Get(Expression<Func<T,bool>>filter);
        void Add(T entity);
      //  void Update(T entity);
        void Reomve(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
