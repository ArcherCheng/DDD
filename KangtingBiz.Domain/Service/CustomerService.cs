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
    public class CustomerService :DomainService<Customer, ICustomerRepository>, ICustomerService
    {
        public CustomerService(ICustomerRepository customerRepository) :
            base(customerRepository)
        {

        }
        public IEnumerable<Customer> GetCustomers(string name)
        {
            IEnumerable<Customer> customers;
            if (name == null || name.Length == 0)
            {
                customers = _repository.FindAll();
            }
            else
            {
                customers = _repository.FindByName(name);
            }
            return customers;
        }
    }
}
