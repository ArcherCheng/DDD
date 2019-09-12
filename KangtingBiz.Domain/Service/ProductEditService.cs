using KangtingBiz.Domain.BizValidation;
using KangtingBiz.Domain.Models;
using KangtingBiz.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KangtingBiz.Domain.Service
{
    public partial class ProductService 
    {
        public Validation Update(int id, int quantity)
        {           
            var product = _repository.FindByID(id);
            var validation = ValidateExistingEntity(product);
            if (!(validation.GetRules().Count() > 0))
            {
                product.ProductHolding.Quantity = quantity;
                _repository.Update(product);
            }
            return validation;
        }
        public void DeleteInclude(int id)
        {
            _repository.DeleteInclude(id); 
        }
    }
}
