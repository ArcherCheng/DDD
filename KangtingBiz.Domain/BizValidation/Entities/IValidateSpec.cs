using KangtingBiz.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KangtingBiz.Domain.BizValidation.Entities
{
    public interface IValidateSpec<TEntity>
        where TEntity : class
    {
        Validation Validate(TEntity entity);       
    }
}
