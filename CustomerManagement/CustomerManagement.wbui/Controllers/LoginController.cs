using CustomerManagement.Business.Service;
using CustomerManagement.Model.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CustomerManagement.wbui.Controllers
{

    public class LoginController : Controller
    {
        public static string name="";
        private IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {

            return View();
        }
        public IActionResult Logout()
        {
              HttpContext.SignOutAsync();
           
            TempData["Danger"] = "<div class='alert alert-success' style='margin-top:25px'>Sistemden başarılı bir şekilde çıkış yaptınız.</div>";
            return Redirect("/login");
        }

        [HttpPost]
        public IActionResult Login(string userName, string sifre)
        {
            if (userName == null || sifre == null)
            {
                TempData["Success"] = "<div class='alert alert-danger' style='margin-top:25px'>Şifre yada kullanıcı adı boş bırakılamaz.</div>";
                return Redirect("/login");
            }
            else
            {
           
                var thereIsUser = _userService.GetAll().Where(p => p.userName == userName && p.userPassword == sifre).FirstOrDefault();

               
                name = thereIsUser.userName;
                if (thereIsUser != null)
                {

                    var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, thereIsUser.userName),
                            new Claim(ClaimTypes.Role, "User"),
                        };
                    var userIdentity = new ClaimsIdentity(claims, "User");

                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                    HttpContext.SignInAsync(principal);
                    return Redirect("/");
                }
                else
                {
                    TempData["Danger"] = "<div class='alert alert-danger' style='margin-top:25px'>Hatalı şifre yada kullanıcı adı.</div>";
                    return Redirect("/login");
                }

            }


        }

        

    }
}
