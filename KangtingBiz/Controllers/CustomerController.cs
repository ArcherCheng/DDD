using KangtingBiz.Application.Service;
using KangtingBiz.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace KangtingBiz.Controllers
{
    public class CustomerController : Controller
    {

        ICustomerAService _customerAService;
        public CustomerController(ICustomerAService customerAService)
        {
            _customerAService = customerAService;
        }
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string SearchName="" )
        {
            if(SearchName.ToString().Length >0)
            { 
                var customers =  _customerAService.GetCustomers(SearchName);
                return View(customers);
            }
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                var validationRule = _customerAService.Create(customer).GetRules();
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
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = _customerAService.Details(Convert.ToInt32(id));
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }
        public ActionResult Edit(int id)
        {
            var customer = _customerAService.Details(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                var validationRule = _customerAService.Update(customer).GetRules();
                int c = validationRule.Count();
                if (c > 0)
                {
                    foreach (var v in validationRule)
                        ModelState.AddModelError("", v.RuleMessage);
                }
                else
                    return RedirectToAction("Index");
            }
            return View(customer);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int removeid)
        {
            _customerAService.Remove(removeid);
            return RedirectToAction("Index");
        }

    }
}