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
    public partial class ProductService: DomainService<Product, IProductRepository>,IProductService
    {       
        public ProductService(IProductRepository productRepository):
            base(productRepository)
        {
            
        }
        public Validation AddInclude(Product product)
        {
            ProductHolding ph = new ProductHolding
            {
                EntityId = product.EntityId,
                Quantity = 0,
                ReorderLevel = 0
            };
            product.ProductHolding = ph; 
            var validation = this.Add(product);         
            return validation;
        }
        public IEnumerable<Product> GetProducts(int id)
        {
            var product = _repository.FindByID(id);
            if (product == null)
                return null;
            else
            {
                List<Product> products = new List<Product>();
                products.Add(product);
                return products;
            }
        }
        public IEnumerable<Product> GetProducts(string name)
        {
            IEnumerable<Product> products;
            if (name == null || name.Length == 0)
            {
                products = _repository.FindAll();
            }
            else
            {
                products = _repository.FindByName(name);
            }
            return products;
        }

       

    }
}
