
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
    public partial class Customer : EntityAggregateRootBase<int>
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
            Address = new AddressInfo();
        }
        [Required(ErrorMessage = "客戶名稱不可空白")]
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "客戶郵件不可空白")]
        public string Email { get; set; }
        // Value Object 
        public AddressInfo Address { get; set; }       
        //
        public virtual ICollection<Order> Orders { get; set; }
        public override Validation Validate()
        {
            var validateSpec = new CustomerValidateSpec();
            Validation validation = validateSpec.Validate(this);
            return validation;
        }
    }
}
