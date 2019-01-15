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
            IEnumerable<CompositionOrder> CompOrders = repository.CompositionOrders;
            Dictionary<int, int> SoldGames = new Dictionary<int, int>();
            foreach (var c in CompOrders)
            {                
                int count = 0;
                if (SoldGames.TryGetValue(c.GameID, out count))
                {
                    count += c.Count;
                    SoldGames[c.GameID] = count;
                }
            }
            //.Where(g => g.OrderID != 0)
            //.OrderBy(g => g.GameID);
            //.GroupBy(g => g.GameID); //OrderID == orderId);
            return View(CompOrders);
        }
        public ViewResult CompositionOrder(int orderId)
        {
            IEnumerable<CompositionOrder> CompOrder = repository.CompositionOrders
                .Where(g => g.OrderID == orderId); //OrderID == orderId);
            return View(CompOrder);
        }
    }
}