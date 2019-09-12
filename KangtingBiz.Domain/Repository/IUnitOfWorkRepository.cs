using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KangtingBiz.Domain.Models;
using System.Data.Entity;

namespace KangtingBiz.Domain.Repository
{
    public interface IUnitOfWorkRepository
    {
        DbContext Context { set; }
    }
}
