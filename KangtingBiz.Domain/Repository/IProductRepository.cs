using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KangtingBiz.Domain.Models;

namespace KangtingBiz.Domain.Repository
{
    public interface IProductRepository:IRepository<Product>, IUnitOfWorkRepository
    {
        Product FindByIDIncludePH(int id);
        IEnumerable<Product> ProductsAdjustment();
        IEnumerable<Product> FindByName(string Name);

        void DeleteInclude(int id); 
    }
}
