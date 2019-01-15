using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GameStore.Domain.Abstract;
using GameStore.Domain.Entities;
using GameStore.WebUI.Models;

namespace GameStore.WebUI.Controllers
{
    [Authorize(Roles = "Admin, Manager")]
    public class OrderController : Controller
    {
        private IOrderRepository repository;
        private ICompositionOrderRepository compositionOrderRepository;
        // GET: Order
        public OrderController(IOrderRepository repo, ICompositionOrderRepository compositionOrderRepo)
        {
            repository = repo;
            compositionOrderRepository = compositionOrderRepo;
        }
        public ViewResult Index()
        {
            return View(repository.Orders);
        }
        public ViewResult OrderComposition()
        {
            return View(compositionOrderRepository.CompositionOrders);
        }
        //[HttpPost]
        //public ViewResult Index(Order order)
        //{
        //    //order.Status = 1;
        //    //repository.SaveOrder(order);
        //    //if (ModelState.IsValid)
        //    //{
        //    //}
        //    return View("Index");
        //}
        //public ViewResult CompositionOrder(int orderId)
        //{
        //    IEnumerable<CompositionOrder> CompOrder = compositionOrderRepository.CompositionOrders
        //        .Where(g => g.OrderID == orderId); //OrderID == orderId);
        //    return View(CompOrder);
        //}
        public ViewResult Edit(int orderId)
        {
            Order order = repository.Orders
                .FirstOrDefault(g => g.OrderID == orderId);
            return View(order);
        }
        [HttpPost]
        public ActionResult Edit(Order order)
        {
            if (ModelState.IsValid)
            {               
                repository.SaveOrder(order);
                TempData["message"] = string.Format("Изменения в заказе № \"{0}\" были сохранены", order.OrderID);
                return RedirectToAction("Index");
            }
            else
            {
                // Что-то не так со значениями данных
                return View(order);
            }
        }
        [HttpPost]
        public ActionResult Delete(int orderid)
        {
            Order deletedOrder = repository.DeleteOrder(orderid);
            //CompositionOrder deletedCompositionOrder = compositionOrderRepository.DeleteCompositionOrder(orderid);
            if (deletedOrder != null)
            {
                TempData["message"] = string.Format("Заказ № \"{0}\" был удалён",
                    deletedOrder.OrderID);
                
            }
            return RedirectToAction("Index");
        }
    }
}