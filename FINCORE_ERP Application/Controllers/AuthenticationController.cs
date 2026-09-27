using FINCORE_ERP_Application.Interfaces;
using FINCORE_ERP_Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace FINCORE_ERP_Application.Controllers
{
    public class AuthenticationController : Controller
    {

        private readonly IAuthenticationService ac;
        public AuthenticationController(IAuthenticationService ac)
        {
            this.ac = ac;
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet]
        public IActionResult LoginPage()
        {
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> SignIn(User u)
        //{
        //    User? loginUser = await ac.SignIn(u.email!, u.pass!);
        //    if (loginUser == null)
        //    {
        //        ViewBag.ErrorMessage = "Invalid email or password";
        //        return LoginPage();
        //    }
        //    HttpContext.Session.SetInt32(
        //        "user_id",
        //        loginUser.user_id);

        //    HttpContext.Session.SetString(
        //        "email",
        //        loginUser.email);
        //    HttpContext.Session.SetString(
        //        "full_name",
        //        loginUser.full_name);

        //}

    }
}
