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
    public class CustomerRepository : EntityRepository<Customer>, ICustomerRepository
    {
        public IEnumerable<Customer> FindByName(string Name)
        {
            var customers = _dbset.Where(c => c.CustomerName.Contains(Name));
            return customers;
        }
    }
}
