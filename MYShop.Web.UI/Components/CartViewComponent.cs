using Microsoft.AspNetCore.Mvc;
using MYShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MYShop.Web.UI.Components
{
    public class CartViewComponent : ViewComponent
    {
        private readonly Cart _cart;
        public CartViewComponent(Cart cart)
        {
            _cart = cart;
        }
        public IViewComponentResult Invoke()
        {

            return View("View", _cart);
        }
    }
}
