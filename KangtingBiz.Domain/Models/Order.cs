
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
    public partial class Order : EntityAggregateRootBase<int>
    {
        public Order()
        {
            OrderLines = new HashSet<OrderLine>();
            ProductTransactions = new HashSet<ProductTransaction>();
            Address = new AddressInfo();
        }

        public int CustomerID { get; set; }
        [Display(Name ="訂購日期",ShortName ="訂購日期S")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime OrderDate { get; set; }
        public string OrderNO { get; set; }


        // Value Object - Begin
        //
        public AddressInfo Address { get; set; }
        
        public virtual Customer Customer { get; set; }
        
        public virtual ICollection<OrderLine> OrderLines { get; set; }        

        public virtual ICollection<ProductTransaction> ProductTransactions { get; set; }

        public override Validation Validate()
        {
            var validateSpec = new OrderValidateSpec();
            Validation validation = validateSpec.Validate(this);
            return validation;
        }
    }
}
