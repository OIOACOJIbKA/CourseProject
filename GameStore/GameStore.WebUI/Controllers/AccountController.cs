using System.Web.Mvc;
//using GameStore.WebUI.Infrastructure.Abstract;
using GameStore.WebUI.Models;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Security.Claims;
using GameStore.WebUI.Infrastructure;
using Microsoft.AspNet.Identity.Owin;
using System.Web;

namespace GameStore.WebUI.Controllers
{
    public class AccountController : Controller
    {
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return View("Error", new string[] { "В доступе отказано" });
            }

            ViewBag.returnUrl = returnUrl; //"/Account/Login";//
            return View();
            //return Redirect("/Account/Login");
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel details, string returnUrl)
        {
            //if (details.UserName != null && details.Password != null) { 
            AppUser user = await UserManager.FindAsync(details.UserName, details.Password);

            if (user == null)
            {
                ModelState.AddModelError("", "Некорректное имя или пароль.");
            }
            else
            {
                ClaimsIdentity ident = await UserManager.CreateIdentityAsync(user,
                    DefaultAuthenticationTypes.ApplicationCookie);

                AuthManager.SignOut();
                AuthManager.SignIn(new AuthenticationProperties
                {
                    IsPersistent = false
                }, ident);
                if (returnUrl == null || returnUrl == "")
                    return Redirect("/Game/List");
                else
                    return Redirect(returnUrl);
            }
            //}
            //else { ModelState.AddModelError("", returnUrl.ToString()); }
            return View(details);
        }

        private IAuthenticationManager AuthManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private AppUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            }
        }

        public ActionResult Logout()
        {
            AuthManager.SignOut();
            return RedirectToAction("List", "Game"); //Home
        }
    }
}