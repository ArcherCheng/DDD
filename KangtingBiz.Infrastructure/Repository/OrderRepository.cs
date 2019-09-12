using KangtingBiz.Domain.Models;
using KangtingBiz.Domain.Repository;
using KangtingBizFlow.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KangtingBiz.Infrastructure.Repository
{
    public class OrderRepository : EntityRepository<Order>, IOrderRepository
    {
        public Order FindByIDRef(int id)
        {
            var order = this.FindByID(id);
            _context.Entry(order).Collection(o => o.OrderLines).Load();
            return order ;
        }
        public IEnumerable<Order> FindByNo(string no)
        {
            var orders = _dbset.Where(o => o.OrderNO.Contains(no));
            return orders;
        }
    }
}
