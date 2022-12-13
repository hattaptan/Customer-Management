using CustomerManagement.Business.Service;
using CustomerManagement.Model.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagement.wbui.Controllers
{
    [Authorize(Roles = "User")]
    public class CustomerController : Controller
    {

        private ICustomerService _customerService;
        private IUserService _userService;


        public CustomerController(ICustomerService customerService, IUserService userService)
        {
            _customerService = customerService;
            _userService = userService;
        }

        // GET: CustomerController
        public ActionResult Index()
        {
            return View();
        }

        
        // GET: CustomerController/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create2(Customers customer)
        {
            
            var newCustomer = _customerService.Add(customer);
                    TempData["Success"] = "<div class='alert alert-danger' style='margin-top:25px'>Müşteri eklendi</div>";
                    return Redirect("/");
            
        }

        // GET: CustomerController/Edit/5
        public ActionResult Check(string button)
        {
            var newid = "";
             for (int i = 0; i < button.Length; i++)
			{
                if(button[i] == '+')
				{
                    newid = button.Substring(i+1);

                }
			}

            var updateCustomer = _customerService.GetById(Int16.Parse(newid));
            updateCustomer.salesAmount += 1; 
            _customerService.Update(updateCustomer);
            return Redirect("/");
        }


        // GET: CustomerController/Delete/5
        public ActionResult Deleted(string button)
        {
            var newid = button.Substring(2); 
            var deleteCustomer = _customerService.GetById(Int16.Parse(newid));
            _customerService.Delete(deleteCustomer);
            return Redirect("/");
        }

    }
}
