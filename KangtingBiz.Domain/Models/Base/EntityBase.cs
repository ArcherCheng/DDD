using System.Collections.Generic;
using KangtingBiz.Domain.BizValidation;
using KangtingBiz.Domain.BizValidation.Entities;

namespace KangtingBiz.Domain.Models.Base
{
    public abstract class EntityBase<T> : IEqualityComparer<EntityBase<T>>
    {       
        public T EntityId { get; set; }
        public bool Equals(EntityBase<T> x, EntityBase<T> y)
        {
            return x.EntityId.ToString() == y.EntityId.ToString();
        }
        public int GetHashCode(EntityBase<T> obj)
        {
            if (obj == null)
                return 0;
            else
                return obj.EntityId.GetHashCode();
        }
        public abstract Validation Validate();        
    }
}
