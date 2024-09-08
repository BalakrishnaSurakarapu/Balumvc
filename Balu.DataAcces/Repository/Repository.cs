using Balu.DataAcces.Data;
using Balu.DataAcces.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Balu.DataAcces.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AplicationDbcontext _db;
        internal DbSet<T> dbset;
        public Repository(AplicationDbcontext db) {
            _db = db;
            this.dbset=_db.Set<T>();
        }

        public void Add(T entity)
        {
            dbset.Add(entity);
        }
        
        
        public T Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbset;
            query=query.Where(filter);
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbset;
            return query.ToList();
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            dbset.RemoveRange(entities);
        }

        public void Reomve(T entity)
        {
            dbset.Remove(entity);
        }
    }
}
