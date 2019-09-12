using KangtingBiz.Domain.BizValidation;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KangtingBiz.Domain.Service.Base
{
    public interface IService<T, TRepository>
    {
        TRepository DomainRepository { get; }
        T Get(int id);
        IEnumerable<T> GetAll();
        Validation Add(T product);        
        Validation Update(T product);
        Validation Delete(int id);
    }
}
