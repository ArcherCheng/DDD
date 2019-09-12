using KangtingBizFlow.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KangtingBiz.Domain.Repository;


namespace KangtingBiz.Infrastructure.Context
{
    public class UnitOfWork : IUnitOfWork, IDisposable         
    {
        private KangtingContext Context = new KangtingContext();        
        public void RegisterRepository(IUnitOfWorkRepository repository)
        {
            repository.Context = Context;
        }
        public void Commit()
        {
            Context.SaveChanges();
        }
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
                disposedValue = true;
            }
        }
        public void Dispose()
        {
            Dispose(true); 
        }

     
    }
}
