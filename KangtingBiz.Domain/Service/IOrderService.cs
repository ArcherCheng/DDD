using KangtingBiz.Domain.BizValidation;
using KangtingBiz.Domain.Models;
using KangtingBiz.Domain.Repository;
using KangtingBiz.Domain.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KangtingBiz.Domain.Service
{
    public interface IOrderService : IService<Order, IOrderRepository>
    {
        Validation AddOrder(Order order);
        Validation AddOrderLine(OrderLine orderLine, IProductService productService);
        Validation UpdateOrderLine(int orderid, int orderlineid, int quantity);
        Validation DeleteOrderLine(int orderid, int orderlineid);

        IEnumerable<Order> GetOrders(string no);
    }
}
