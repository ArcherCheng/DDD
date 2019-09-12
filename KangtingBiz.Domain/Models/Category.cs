using KangtingBiz.Domain.BizValidation;
using KangtingBiz.Domain.BizValidation.Entities;
using KangtingBiz.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KangtingBiz.Domain.Models
{
    public class Category : EntityAggregateRootBase<int>
    {       
        public string CategoryName { get; set; }
        public override Validation Validate()
        {
            var validateSpec = new CategoryValidateSpec();
            Validation validation = validateSpec.Validate(this);
            return validation;
        }
       
    }
}
