using KangtingBiz.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KangtingBiz.Domain.BizValidation.Entities
{
    public class ProductValidateSpec : IValidateSpec<Product>
    {
        Validation validation = new Validation();
        public Validation Validate(Product product)
        {            
            if (product.UnitPrice < 0)
            {
                string errorMessage = "商品單價必須大於 0 ";
                validation.AddRule(new ValidationRule(errorMessage));
            }
            if (product.ProductName.Length < 2)
            {
                string errorMessage = "商品名稱必須至少兩個字元 ";
                validation.AddRule(new ValidationRule(errorMessage));
            }
            return validation;
        }


    }
}
