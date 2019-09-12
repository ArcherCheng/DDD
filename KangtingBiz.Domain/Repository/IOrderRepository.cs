using KangtingBiz.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KangtingBiz.Domain.Repository
{
    public interface IOrderRepository : IRepository<Order>, IUnitOfWorkRepository
    {
        Order FindByIDRef(int id);
        IEnumerable<Order> FindByNo(string no);
    }
}
