using System.Linq;
using System.Web.Mvc;
using GameStore.Domain.Entities;
using GameStore.Domain.Abstract;
using GameStore.WebUI.Models;

namespace GameStore.WebUI.Controllers
{
    //[Authorize(Roles = "User")]
    public class CartController : Controller
    {
        private IGameRepository repository;
        private IOrderRepository orderRepository;
        private ICompositionOrderRepository compositionOrderRepository;

        public CartController(IGameRepository repo, IOrderRepository orderRepo, ICompositionOrderRepository compositionOrderRepo)
        {
            repository = repo;
            orderRepository = orderRepo;
            compositionOrderRepository = compositionOrderRepo;
        }
        [Authorize]
        public ViewResult Checkout()
        {
            return View(new Order());
        }

        [HttpPost]
        public ViewResult Checkout(Cart cart, Order order)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Извините, ваша корзина пуста!");
            }

            if (ModelState.IsValid)
            {
                //orderProcessor.ProcessOrder(cart, order);
                decimal sum = 0;
                foreach (var c in cart.Lines)
                {
                    sum += c.Game.Price * c.Quantity;
                }
                order.Price = sum;// Summary(cart);
                order.Status = 0;
                order.Date = System.DateTime.Now;
                order.UserName = User.Identity.Name;

                orderRepository.SaveOrder(order);
                compositionOrderRepository.CreateCompositionOrder(order, cart);
                
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(order);
            }
        }

        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }
        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }

        public RedirectToRouteResult AddToCart(Cart cart, int gameId, string returnUrl)
        {
            Game game = repository.Games
                .FirstOrDefault(g => g.GameId == gameId);

            if (game != null)
            {
                cart.AddItem(game, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int gameId, string returnUrl)
        {
            Game game = repository.Games
                .FirstOrDefault(g => g.GameId == gameId);

            if (game != null)
            {
                cart.RemoveLine(game);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
    }
}