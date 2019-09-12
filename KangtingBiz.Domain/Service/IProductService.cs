using KangtingBiz.Domain.BizValidation;

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
    public interface IProductService:IService<Product, IProductRepository>
    {
        IEnumerable<Product> GetProducts(string name );
        IEnumerable<Product> GetProducts(int id);
        //
        Validation AddInclude(Product product);
        Validation Update(int id, int quantity);
        void DeleteInclude(int id);
    }
}
