using KangtingBiz.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KangtingBiz.Domain.BizValidation.Entities
{
    public class OrderValidateSpec:IValidateSpec<Order>
    {
        Validation validation = new Validation();
        public Validation Validate(Order order)
        {
            return validation;
        }
    }
}
