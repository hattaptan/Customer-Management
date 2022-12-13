using CustomerManagement.Business.Service;
using CustomerManagement.Model.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CustomerManagement.wbui.Controllers
{
    public class RegisterController : Controller
    {
        private IUserService _userService;

        public RegisterController(IUserService userService)
        {
            _userService = _userService;
        }

        public IActionResult Index()
        {


            return View();
        }

        //[HttpPost]
        //public IActionResult NewReg(string userNam, string userPassword)
        //{
             
        //    return Redirect("/Login");
        //}
        [HttpPost]
         public   IActionResult  NewReg(string userName, string userPassword)
        {

             

            if ( userName !=null || userPassword!=null)
            {
                Users usr = new Users()
                {
                    userName = userName,
                    userPassword = userPassword
                };
                _userService.Add(usr);
                TempData["Success"] = "<div class='alert alert-danger' style='margin-top:25px'>Üyelik Kaydı Başarılı</div>";


            }


            return Redirect("/Login");
        }
    }
}
