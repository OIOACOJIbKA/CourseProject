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
        [HttpPost]
        public ViewResult Index(Order order)
        {
            order.Status = 1;
            repository.Status1(order);
            if (ModelState.IsValid)
            {
            }
            return View("Index");
        }
        public ActionResult Edit(Order order)
        {
            return View(order);
        }
    }
}