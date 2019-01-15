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
        // GET: Order
        public OrderController(IOrderRepository repo)
        {
            repository = repo;
        }
        public ActionResult Index()
        {
            return View(repository.Orders);
        }
    }
}