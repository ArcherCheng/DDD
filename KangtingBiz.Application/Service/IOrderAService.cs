using KangtingBiz.Domain.BizValidation;
using KangtingBiz.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KangtingBiz.Application.Service
{
    public interface IOrderAService : IApplicationService<Order>
    {
        Validation CreateOrder(Order entity);
        Validation AppendOrderLine(OrderLine entity);
        Validation EditOrderLine(int orderid, int orderlineid, int quantity);
        Validation RemoveOrderLine(int orderid, int orderlineid);

        IEnumerable<Order> GetOrders(string no); 
    }
}
