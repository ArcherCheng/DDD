using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KangtingBiz.Domain.Models;

namespace KangtingBiz.Application.Service
{
    public interface ICategoryAService : IApplicationService<Category>
    {
        IEnumerable<Category> GetCategories(string name);
    }
}
