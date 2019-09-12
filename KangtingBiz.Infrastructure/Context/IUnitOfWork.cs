using KangtingBiz.Domain.Repository;

using KangtingBizFlow.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KangtingBiz.Infrastructure.Context
{    
    public interface IUnitOfWork
    {
        void RegisterRepository(IUnitOfWorkRepository repository);
        void Commit();
    }
}
