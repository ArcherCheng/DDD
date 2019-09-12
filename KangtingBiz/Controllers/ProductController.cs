using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KangtingBiz.Application.DTOS;
using KangtingBiz.Application.Service;
using KangtingBiz.Domain.Models;

namespace KangtingBiz.Controllers
{
    public class ProductController : Controller
    {
        IProductAService _productAService;
        public ProductController(IProductAService productAService)
        {
            _productAService = productAService;
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(SearchProductRequest request)
        {
            var products = _productAService.GetProducts(request);
            return View(products);
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _productAService.Details(Convert.ToInt32(id)); 
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            //System.Diagnostics.Debug.WriteLine(ModelState.IsValid.ToString());

            if (ModelState.IsValid)
            {
                var validationRule = _productAService.CreateInclude(product).GetRules();
                int c = validationRule.Count();
                if (c > 0)
                {
                    foreach (var v in validationRule)
                        ModelState.AddModelError("", v.RuleMessage);
                }
                else
                    return RedirectToAction("Index");
            }
            return View(product);  
        }

        public ActionResult Edit(int? id)
        {
            if (id==null)
            {              
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product = _productAService.Details(Convert.ToInt32(id));
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                var validationRule = _productAService.Update(product).GetRules();
                int c = validationRule.Count();
                if (c > 0)
                {
                    foreach (var v in validationRule)
                        ModelState.AddModelError("", v.RuleMessage);
                }
                else
                    return RedirectToAction("Index");
            }
            return View(product);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int removeid)
        {            
             _productAService.RemoveInclude(removeid);
            return RedirectToAction("Index");
        }

    }
}