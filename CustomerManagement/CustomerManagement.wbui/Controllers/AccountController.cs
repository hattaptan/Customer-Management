using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagement.wbui.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {

        public IActionResult AccessDenied()
        {

            var html = "<div class='alert alert-warning alert-dismissible fade show' role='alert'>" +
                     "<strong>Yetkisiz Giriş! </strong> Yetkinizin olmadığı bir sayfaya erişmeye çalışıyorsunuz. Yetkili olduğunuz sayfaya yönlendirildiniz." +
                     "<button type='button' class='close' data-dismiss='alert' aria-label='Close'>" +
                     "<span aria-hidden='true'>&times;</span>" +
                     "</button>" +
                 "</div>";

            TempData["Success"] = html;

            return Redirect("/Login");

        }
    }
}
