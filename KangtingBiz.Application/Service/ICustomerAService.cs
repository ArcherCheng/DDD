using KangtingBiz.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KangtingBiz.Application.Service
{
    public interface ICustomerAService : IApplicationService<Customer>
    {
        IEnumerable<Customer> GetCustomers(string name );
    }
}
