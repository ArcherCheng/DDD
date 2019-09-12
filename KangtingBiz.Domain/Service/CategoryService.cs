using KangtingBiz.Domain.Models;
using KangtingBiz.Domain.Repository;
using KangtingBiz.Domain.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KangtingBiz.Domain.Service
{
    public class CategoryService : DomainService<Category, ICategoryRepository>,ICategoryService
    {
        public CategoryService(ICategoryRepository categoryRepository) :
            base(categoryRepository)
        {

        }
        public IEnumerable<Category> GetCategories(string name)
        {
            IEnumerable<Category> customers;
            if (name == null || name.Length == 0)
            {
                customers = _repository.FindAll();
            }
            else
            {
                customers = _repository.FindByName(name);
            }
            return customers;
        }
    }
}
