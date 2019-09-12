using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KangtingBiz.Domain.Models;
using KangtingBiz.Domain.Models.Base;

namespace KangtingBiz.Domain.Repository
{
    public interface IRepository<TEntity>        
    {
        TEntity FindByID(int id);
        IEnumerable<TEntity> FindAll();      
        
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);      
    }
}
