using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KangtingBiz.Domain.BizValidation;
using KangtingBiz.Domain.Models;
using KangtingBiz.Domain.Repository;
using KangtingBiz.Domain.Service;
using KangtingBiz.Infrastructure.Context;

namespace KangtingBiz.Application.Service
{
    public class CategoryAService : 
        ApplicationService<Category, ICategoryRepository, 
            ICategoryService>,ICategoryAService
    {
        public CategoryAService(
             ICategoryService categoryService,
             IUnitOfWork uow) : base(categoryService, uow) { }

        public IEnumerable<Category> GetCategories(string name)
        {
            var categories = _service.GetCategories(name).ToList();
            if (categories.Count > 0)
                return categories;
            return null;
        }
    }
}
