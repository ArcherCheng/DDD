
using KangtingBiz.Domain.Repository;
using KangtingBiz.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KangtingBizFlow.Infrastructure.Repository
{
    public class EntityRepository<T> : IRepository<T> , IUnitOfWorkRepository
        where T:class
    {
        internal KangtingContext _context;
        internal DbSet<T> _dbset;

        public DbContext Context
        {
            set
            {
                _context = (KangtingContext)value;
                _dbset = _context.Set<T>();
            }
        }
        public IEnumerable<T> FindAll()
        {
            return _dbset;
        }
        public T FindByID(int id)
        {
            return _dbset.Find(id);
        }
        public void Add(T entity)
        {
            _dbset.Add(entity);          
        }
        public void Delete(T entity)
        {
            _dbset.Remove(entity);           
        }
        public void Update(T entity)
        {            
            var entry = _context.Entry(entity);
            _dbset.Attach(entity);
            entry.State = EntityState.Modified;          
        }       
    }
}
