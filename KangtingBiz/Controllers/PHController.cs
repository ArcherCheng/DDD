using KangtingBiz.Application.DTOS;
using KangtingBiz.Application.Service;
using KangtingBiz.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KangtingBiz.Controllers
{
    public class PHController : Controller
    {
        // GET: PH
        IProductAService _productAService;
        public PHController(IProductAService productAService)
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
        public ActionResult Edit(int id)
        {
            var product = _productAService.Details(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, int quantity)
        {
            System.Diagnostics.Debug.WriteLine(id + "," + quantity);
            if (ModelState.IsValid)
            {
                var validationRule = 
                    _productAService.Update(id, quantity).GetRules();
                int c = validationRule.Count();
                if (c > 0)
                {
                    foreach (var v in validationRule)
                        ModelState.AddModelError("", v.RuleMessage);
                }
            }
            return RedirectToAction("Edit",id);
        }
    }
}