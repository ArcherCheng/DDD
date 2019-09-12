using KangtingBiz.Application.Service;
using KangtingBiz.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;
using KangtingBiz.Domain.BizValidation;
using System.Net;

namespace KangtingBiz.Controllers
{
    public class CategoryController : Controller
    {
        ICategoryAService _categoryAService;
        public CategoryController(ICategoryAService categoryAService)
        {
            _categoryAService = categoryAService;
        }
        // GET: Category
        public ActionResult Index()
        {
            var categories =   _categoryAService.ListAll(); 
            return View(categories);
        }

        [HttpPost]
        public ActionResult Index(string name)
        {
            var categories = _categoryAService.GetCategories(name);
            return View(categories);
        }

        public ActionResult Create()
        {            
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                var validationRule = _categoryAService.Create(category).GetRules();
                int c = validationRule.Count();
                if (c > 0)
                {
                    foreach (var v in validationRule)
                        ModelState.AddModelError("", v.RuleMessage);
                }
                else
                    return RedirectToAction("Index");
            }           
            return View();
        }

        public ActionResult Edit(int id)
        {
            var category = _categoryAService.Details(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                var validationRule = _categoryAService.Update(category).GetRules();
                int c = validationRule.Count();
                if (c > 0)
                {
                    foreach (var v in validationRule)
                        ModelState.AddModelError("", v.RuleMessage);
                }
                else
                    return RedirectToAction("Index");
            }
            return View(category);
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = _categoryAService.Details(Convert.ToInt32(id));
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int removeid)
        {
            _categoryAService.Remove(removeid);
            return RedirectToAction("Index");
        }
    }

}