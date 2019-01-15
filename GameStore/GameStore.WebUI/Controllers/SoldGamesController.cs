using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GameStore.Domain.Abstract;
using GameStore.Domain.Entities;

namespace GameStore.WebUI.Controllers
{
    [Authorize(Roles = "Admin, Manager")]
    public class SoldGamesController : Controller
    {
        private ICompositionOrderRepository repository;
        private IGameRepository gameRepository;
        public SoldGamesController(IGameRepository gameRepo, ICompositionOrderRepository repo)
        {
            gameRepository = gameRepo;
            repository = repo;
        }
        // GET: SoldGames
        public ViewResult Index()
        {
            IEnumerable<CompositionOrder> CompOrders = repository.CompositionOrders;
            List<SoldGames> soldGames = new List<SoldGames>();
            Dictionary<int, int> dickSoldGames = new Dictionary<int, int>();
            foreach (var c in CompOrders)
            {
                int count = 0;
                if (dickSoldGames.TryGetValue(c.GameID, out count))
                {
                    count += c.Count;
                    dickSoldGames[c.GameID] = count;
                }
                else
                {
                    dickSoldGames.Add(c.GameID, c.Count);
                }
            }
            foreach (var s in dickSoldGames)
            {
                Game game = gameRepository.Games.FirstOrDefault(g => g.GameId == s.Key);
                soldGames.Add(new SoldGames
                {
                    GameName = game.Name,
                    GamePrice = game.Price,
                    GameCount = s.Value,
                    TotalPrice = game.Price * s.Value
                });
            }
            return View(soldGames);
        }
    }
}