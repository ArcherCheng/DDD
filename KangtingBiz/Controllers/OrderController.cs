using KangtingBiz.Application.Service;
using KangtingBiz.Domain.BizValidation;
using KangtingBiz.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KangtingBiz.Controllers
{
    public class OrderController : Controller
    {
        private IOrderAService _orderAService;
        public OrderController(IOrderAService orderAService)
        {
            _orderAService = orderAService;
        }
        // GET: Order
        public ActionResult Index()
        {
            var list = _orderAService.ListAll();
            return View(list);
        }
        //[HttpPost]
        //public ActionResult Index(int id)
        //{
        //    var list = _orderAService.ListAll();
        //    return View(list);
        //}

        [HttpPost]
        public ActionResult Index(string no)
        {
            var list = _orderAService.GetOrders(no);
            return View(list);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Order order)
        {
            if (ModelState.IsValid)
            {
                var validationRule = _orderAService.CreateOrder(order).GetRules();
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
            var order = _orderAService.Details(id);
            if (order == null)
            {
                return HttpNotFound();
            }

            return View(order);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Order order)
        {
            if (ModelState.IsValid)
            {
                var validationRule = _orderAService.Update(order).GetRules();
                int c = validationRule.Count();
                if (c > 0)
                {
                    foreach (var v in validationRule)
                        ModelState.AddModelError("", v.RuleMessage);
                }
                else
                    return RedirectToAction("Index");
            }
            return View(order);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOrderLine(OrderLine orderLine)
        {
            if (ModelState.IsValid)
            {
                var validationRule = _orderAService.AppendOrderLine(orderLine).GetRules();

                if (validationRule != null)
                {
                    //System.Diagnostics.Debug.WriteLine("NOT NULL");
                    int c = validationRule.Count();
                    if (c > 0)
                    {
                        var msg = "";
                        foreach (var v in validationRule)
                        {
                            msg += "Error Message <br/>" + v.RuleMessage;
                        }
                        return Content(msg);
                    }
                }
            }
            return RedirectToAction("Edit", new { id = orderLine.OrderID });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditOrderLine(int orderid, int orderlineid, int quantity)
        {
            var validationRule = _orderAService.EditOrderLine(orderid, orderlineid, quantity).GetRules();
            if (validationRule != null)
            {
                int c = validationRule.Count();
                if (c > 0)
                {
                    var msg = "";
                    foreach (var v in validationRule)
                    {
                        msg += "Error Message <br/>" + v.RuleMessage;
                    }
                    return Content(msg);
                }
            }
            return RedirectToAction("Edit", new { id = orderid });
        }

        public ActionResult RemoveOrderLine(int id, int orderlineid)
        {
            var validationRule = _orderAService.RemoveOrderLine(id, orderlineid).GetRules();
            if (validationRule != null)
            {
                int c = validationRule.Count();
                if (c > 0)
                {
                    var msg = "";
                    foreach (var v in validationRule)
                    {
                        msg += "Error Message <br/>" + v.RuleMessage;
                    }
                    return Content(msg);
                }
            }
            return RedirectToAction("Edit", new { id });
        }



        public ActionResult DeleteConfirmed(int id)
        {
            var validationRule = _orderAService.Remove(id);
            System.Diagnostics.Debug.WriteLine(id);
            return RedirectToAction("Index");
        }
    }
}