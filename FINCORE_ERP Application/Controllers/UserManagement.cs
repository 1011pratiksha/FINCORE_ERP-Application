using Microsoft.AspNetCore.Mvc;

namespace FINCORE_ERP_Application.Controllers
{
    public class UserManagement : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        //view for  User page
        public IActionResult user_page()
        {
            return View();
        }

        //view for  role page
        public IActionResult role_page()
        {
            return View();
        }

    }
}
