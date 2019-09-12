using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KangtingBiz.Domain.Models.Base
{
    public abstract class EntityAggregateRootBase<T> : EntityBase<T>, IAggregateRoot
    {

    }
}
