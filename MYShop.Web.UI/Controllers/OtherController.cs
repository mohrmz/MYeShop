using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MYShop.Web.UI.Controllers
{
    public class OtherController : Controller
    {
        public IActionResult Harim()
        {
            return View();
        }
        public IActionResult Sefaresh()
        {
            return View();
        }
        public IActionResult HelpPay()
        {
            return View();
        }
        public IActionResult US()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Address()
        {
            return View();
        }
    }
}