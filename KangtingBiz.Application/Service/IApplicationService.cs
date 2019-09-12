using KangtingBiz.Domain.BizValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KangtingBiz.Application.Service
{
    public interface IApplicationService<T>        
    {
        T Details(int id);
        IEnumerable<T> ListAll(); 
        Validation Create(T entity);
        Validation Update(T entity);       
        Validation Remove(int id);
    }
}
