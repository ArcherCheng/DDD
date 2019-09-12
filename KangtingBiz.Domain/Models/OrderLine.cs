using KangtingBiz.Domain.BizValidation;
using KangtingBiz.Domain.BizValidation.Entities;
using KangtingBiz.Domain.Models.Base;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace KangtingBiz.Domain.Models
{
    public partial class OrderLine : EntityBase<int>
    {
        public int OrderID { get; set; }

        public int ProductID { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }

        public override Validation Validate()
        {
            var validateSpec = new OrderLineValidateSpec();
            Validation validation = validateSpec.Validate(this);
            return validation;
        }
    }
}
