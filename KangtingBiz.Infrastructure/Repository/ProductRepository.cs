using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using KangtingBiz.Domain.Models;
using KangtingBiz.Domain.Repository;

namespace KangtingBizFlow.Infrastructure.Repository
{
    public class ProductRepository:EntityRepository<Product>,  IProductRepository
    {
        public Product FindByIDIncludePH(int id)
        {
            var product = _dbset.Where(p => p.EntityId == id).Include("ProductHolding").SingleOrDefault();
            return product;
        }
        public IEnumerable<Product> FindByName(string Name)
        {
            var products = _dbset.Where(p => p.ProductName.Contains(Name));
            return products; 
        }
        public IEnumerable<Product> ProductsAdjustment()
        {
            IEnumerable<Product> products =
                _dbset.Where(p => p.ProductHolding.Quantity <= p.ProductHolding.ReorderLevel);
            return products;
        }

        public void DeleteInclude(int id)
        {
            var product = FindByIDIncludePH(id);            
            if (product != null)
            {
                this.Delete(product);
            }
        }

         

     
    }
}