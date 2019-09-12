using KangtingBiz.Domain.BizValidation;
using KangtingBiz.Domain.BizValidation.Entities;
using KangtingBiz.Domain.Models.Base;

using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace KangtingBiz.Domain.Models
{
    public partial class Product : EntityAggregateRootBase<int>
    {
        public Product()
        {
            ProductTransactions = new HashSet<ProductTransaction>();
        }
        [Required(ErrorMessage ="商品名稱不可空白" )]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "商品價格不可空白")]
        public decimal? UnitPrice { get; set; }

        public int? CategoryID { get; set; }

        public string Description { get; set; }

        public virtual ProductHolding ProductHolding { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<ProductTransaction> ProductTransactions { get; set; }

        public override Validation Validate()
        {
            var validateSpec = new ProductValidateSpec();
            Validation validation = validateSpec.Validate(this);
            return validation;
        }
    }
}
