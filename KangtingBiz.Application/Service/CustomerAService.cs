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
    public class CustomerAService :
        ApplicationService<Customer, ICustomerRepository, ICustomerService>,
        ICustomerAService
    {
        public CustomerAService(
             ICustomerService customerService,
             IUnitOfWork uow) : base(customerService, uow) { }

        public IEnumerable<Customer> GetCustomers(string name)
        {
            var customers = _service.GetCustomers(name).ToList();
            if (customers.Count > 0)
                return customers;
            return null;          
        }

       
    }
}
