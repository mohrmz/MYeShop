using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MYShop.Web.UI.Controllers
{
    public class ArticleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult toshak()
        {
            return View();
        }
        public IActionResult balesh()
        {
            return View();
        }
        public IActionResult harfzadandarkhab()
        {
            return View();
        }

    }
}