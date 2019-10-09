using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MYShop.Domain.Contract.Repositories;
using MYShop.Domain.Entities;
using System.Linq;

namespace MYShop.Web.UI.Controllers
{
    public class CartController : Controller
    {
        private IProductRepository repository;
        private Cart _cart;
        public CartController(IProductRepository repo, Cart cart)
        {
            repository = repo;
            _cart = cart;

        }
        public IActionResult Index()
        {
           if (_cart.Lines.Count() == 0)
            {
                return RedirectToAction("index", "Home");
            }
           else
            {
                return View(_cart);
            }
           
        }
        public IActionResult AddToCart(int productId,int priceid ,int price)
        {
            
            Product product = repository.GetById(productId);
            if (product != null)
            {
                _cart.AddItem(product, priceid, price, 1);
            }
  
            return RedirectToAction("Index", "Cart");
        }
        public IActionResult misfromCart(int productId)
        {
            Product product = repository.GetById(productId);
            if (product != null)
            {
                _cart.minfromItem(product,1);
            }
            return RedirectToAction("Index", "Cart");
        }
        public IActionResult RemoveFromCart(int productId, string returnUrl)
        {
            Product product = repository.GetById(productId);
            if (product != null)
            {
                _cart.RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
    }
}