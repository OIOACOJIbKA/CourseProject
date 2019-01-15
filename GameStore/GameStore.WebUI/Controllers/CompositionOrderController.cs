using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GameStore.Domain.Abstract;
using GameStore.Domain.Entities;

namespace GameStore.WebUI.Controllers
{
    public class CompositionOrderController : Controller
    {
        // GET: CompositionOrder
        private ICompositionOrderRepository repository;

        public CompositionOrderController(ICompositionOrderRepository repo)
        {
            repository = repo;
        }
        public ViewResult Index()
        {
            return View(repository.CompositionOrders);
        }
        public ViewResult CompositionOrder(int orderId)
        {
            CompositionOrder CompOrder = repository.CompositionOrders
                .FirstOrDefault(g => g.CompositionOrderID == orderId); //OrderID == orderId);
            return View(CompOrder);
        }
        //[HttpPost]
        //public ActionResult Edit(Order order)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        //repository.SaveOrder(order);
        //        TempData["message"] = string.Format("Изменения в заказе № \"{0}\" были сохранены", order.OrderID);
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        // Что-то не так со значениями данных
        //        return View(order);
        //    }
        //}
        //public PartialViewResult CompositionOrder()//int orderID)
        //{
        //    //CompositionOrder compositionOrder = repository.CompositionOrders;
        //    //ienumerable<string> categories = repository.compositionorders
        //    //    .select(compositionorder => compositionorder.orderid)
        //    //    .distinct()
        //    //    .orderby(x => x);

        //    return PartialView(/*"CompositionOrder", */repository.CompositionOrders);

        //}
    }
}