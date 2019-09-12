using KangtingBiz.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KangtingBiz.Domain.BizValidation.Entities
{
    public class CategoryValidateSpec : IValidateSpec<Category>
    {
        Validation validation = new Validation();
        public Validation Validate(Category entity)
        {
            return validation;
        }
    }
}
