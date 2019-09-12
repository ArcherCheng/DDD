using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

using KangtingBiz.Domain.Models;
using KangtingBiz.Domain.Repository;
using KangtingBizFlow.Infrastructure.Repository;

namespace KangtingBiz.Infrastructure.Repository
{
    public class CategoryRepository : EntityRepository<Category>, ICategoryRepository
    {
        public IEnumerable<Category> FindByName(string name)
        {
            var categories = _dbset.Where(c => c.CategoryName.Contains(name));
            return categories ;
        }
    }
}
