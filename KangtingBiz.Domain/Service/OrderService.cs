using KangtingBiz.Domain.BizValidation;
using KangtingBiz.Domain.Models;
using KangtingBiz.Domain.Repository;
using KangtingBiz.Domain.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data; 
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace KangtingBiz.Domain.Service
{
    public class OrderService : DomainService<Order, IOrderRepository>, IOrderService
    {
        public OrderService(IOrderRepository orderRepository) :
            base(orderRepository)
        {
        }
        public Validation AddOrder(Order order)
        {
            string lastid = _repository.FindAll().Last().EntityId.ToString().PadLeft(6, '0');
            var orderNO = DateTime.Now.ToString("yyyyMMddHHmmss") + lastid;
            order.OrderNO = orderNO;
            order.OrderDate = DateTime.Now;
            var validation = this.Add(order);
            return validation;
        }
        public Validation AddOrderLine(OrderLine orderLine, IProductService productService)
        {
            var orderid = orderLine.OrderID;
            var order = _repository.FindByIDRef(orderid);
            int orderlineid = order.OrderLines.LastOrDefault() ==null ? 
                orderid * 1000 +1:
                order.OrderLines.Last().EntityId + 1;

            decimal? price = productService.Get(orderLine.ProductID).UnitPrice;
            orderLine.EntityId = orderlineid; 
            orderLine.UnitPrice = Convert.ToDecimal(price);
            order.OrderLines.Add(orderLine);
            var validation = this.Update(order);
            return validation;
        }
        public Validation UpdateOrderLine(int orderid, int orderlineid, int quantity)
        {
            var order = _repository.FindByID(orderid);
            var orderLine = order.
                OrderLines.
                SingleOrDefault(ol => ol.EntityId == orderlineid);

            orderLine.Quantity = quantity;
            var validation = this.Update(order);
            return validation;
        }
        public Validation DeleteOrderLine(int orderid , int orderlineid)
        {
            var order = _repository.FindByIDRef(orderid)   ;
            // order.OrderLines = null; 
            var orderline = order.OrderLines.Single(ol => ol.EntityId == orderlineid);
            order.OrderLines.Remove(orderline); 
            var validation = this.Update(order);         
            return validation;
        }
        public IEnumerable<Order> GetOrders(string no)
        {
            var orders  = _repository.FindByNo(no);
            return orders; 
        }
    }
}
