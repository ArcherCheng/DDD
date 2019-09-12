using KangtingBiz.Domain.BizValidation;
using KangtingBiz.Domain.Models;
using KangtingBiz.Domain.Repository;
using KangtingBiz.Domain.Service;
using KangtingBiz.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KangtingBiz.Application.Service
{
    public class OrderAService :
        ApplicationService<Order, IOrderRepository, IOrderService>,
        IOrderAService
    {
        IProductService _productService;
        public OrderAService(
             IOrderService orderService,
             IProductService productService,
             IUnitOfWork uow) : base(orderService, uow)
        {

            _productService = productService;
            _uow.RegisterRepository((IUnitOfWorkRepository)_productService.DomainRepository);
        }
        public Validation CreateOrder(Order entity)
        {
            try
            {
                _validation = _service.AddOrder(entity);
                UowCommit();
            }
            catch (Exception ex)
            {
                string msg = ex.ToString();
                _validation.AddRule(new ValidationRule(msg));
            }
            return _validation;
        }
        public IEnumerable<Order> GetOrders(string no)
        {
            var orders = _service.GetOrders(no);
            return orders ; 
        }
        public Validation AppendOrderLine(OrderLine entity)
        {
            try
            {
                _validation = _service.AddOrderLine(entity, _productService);
                UowCommit();
            }
            catch (Exception ex)
            {
                string msg = ex.ToString();
                _validation.AddRule(new ValidationRule(msg));
            }
            return _validation;
        }
        public Validation EditOrderLine(int orderid,int orderlineid, int quantity)
        {
            try
            {
                _validation = _service.UpdateOrderLine(orderid,orderlineid,quantity);
                UowCommit();
            }
            catch (Exception ex)
            {
                string msg = ex.ToString();
                _validation.AddRule(new ValidationRule(msg));
            }
            return _validation;
        }
        public Validation RemoveOrderLine(int orderid, int orderlineid)
        {
            try
            {
                _validation = _service.DeleteOrderLine(orderid, orderlineid);
                UowCommit();
            }
            catch (Exception ex)
            {
                string msg = ex.ToString();
                _validation.AddRule(new ValidationRule(msg));
            }
            return _validation;
        }
    }

}

   
