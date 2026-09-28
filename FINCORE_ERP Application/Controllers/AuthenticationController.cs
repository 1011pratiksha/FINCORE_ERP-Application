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

        [HttpPost]
        public async Task<IActionResult> SignIn(string Email, string Password)
        {
           var role = await ac.SignIn(Email, Password);
            if (role == null)
            {
                ViewBag.ErrorMessage = "Invalid email or password";
                return LoginPage();
            }

            var user = await ac.GetUserByEmail(Email);

            HttpContext.Session.SetInt32("user_id", user.user_id);

            HttpContext.Session.SetString("email", user.email);
            HttpContext.Session.SetString("full_name",user.full_name);

            switch (role)
            {
                case "Admin":
                    return RedirectToAction("AdminDashboard", "Dashboard");
                case "Finance Manager":
                    return RedirectToAction("FinanceManagerDashboard", "Dashboard"); 
                case "Procurement Officer":
                    return RedirectToAction("ProcurementManagerDashboard", "Dashboard"); 
                case "Department Head":
                    return RedirectToAction("DepartmentHeadDashboard", "Dashboard");
                case "Employee":
                    return RedirectToAction("EmployeeDashboard", "Dashboard"); 
                case "Auditor":
                    return RedirectToAction("AuditorDashboard", "Dashboard");
                case "CFO":
                    return RedirectToAction("CFODashboard", "Dashboard"); 
                default:
                    TempData["Error"] = "Unauthorized Role Access Profile.";
                    return RedirectToAction("LoginPage", "Authentication");
            }
            TempData["Error"] = "Invalid Email or Password";

            return RedirectToAction("SignIn");
        }

    }
}
