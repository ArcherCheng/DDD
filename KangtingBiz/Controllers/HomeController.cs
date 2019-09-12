using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KangtingBiz.Application.Service;
using KangtingBiz.Domain.BizValidation;
using KangtingBiz.Domain.Models;
using KangtingBiz.Domain.Service;
using KangtingBiz.Infrastructure.Context;
using KangtingBizFlow.Infrastructure.Repository;

namespace KangtingBiz.Controllers
{
    public class HomeController : Controller
    {
        IProductAService _productAService;
        public HomeController(IProductAService productAService)
        {
            _productAService = productAService;
        }
        public ActionResult Index()
        {            
            return View();
        }      
    }
}

/* Product p = new Product()
            {
                ProductName = "TestBook",
                Description = "TestBook Desc ",
                UnitPrice = 100
            };
            ProductAService paService = new ProductAService(
                new ProductService(new ProductRepository()) ,
                new UnitOfWork());

            paService.Create(p); 


      public ActionResult ProductValidate()
        {
            Product p = new Product()
            {
                ProductName = "TestBook",
                Description = "TestBook Desc ",
                UnitPrice = -100
            };
            Validation validations = p.Validate();
            int c = validations.GetRules().Count();
            return Content(c.ToString());
        }
 * 
 * */


