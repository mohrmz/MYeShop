using Microsoft.AspNetCore.Mvc;
using MYShop.Domain.Contract.Repositories;
using MYShop.Domain.Entities;
using MYShop.Web.UI.Models;

using System.Linq;

namespace MYShop.Web.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductRepository _repo;
        private readonly INewsUserRespository _repo1;
        private readonly ICommentRepository _repo2;
        private readonly IPropertyRepository _repo3;
        private readonly CompareProduct CompareProduct;
        private int pagesize = 6;
        public HomeController(IProductRepository repo, INewsUserRespository repo1, ICommentRepository repo2,IPropertyRepository repo3, CompareProduct compareProduct)
        {
            _repo = repo;
            _repo1 = repo1;
            _repo2 = repo2;
            _repo3 = repo3;
            CompareProduct = compareProduct;
        }

        public IActionResult Index(int CategoryId, string value, int page =1)
        {

            ViewBag.bb = _repo.GetAllCategories();
            HomeViewModel model = new HomeViewModel();
            model.Category = CategoryId;
            model.Result = _repo.GetPagedData(CategoryId, page, value, pagesize);
            return View(model);
        }
        public IActionResult Product(Product product)
        {
            var result = _repo.FindById(product.ProductID);
            
            return View(result);
        }
        public IActionResult Find(string term)
        {
            var result = _repo.Find(term);

            return Json(new { results = (result.Select(c => new { id = c.ProductID, text = c.Name })) });
        }
        public IActionResult newsuser(string email)
        {
            string result = _repo1.SaveCategory(email);
            ViewBag.result = result;
            return View("result");
        }
        public IActionResult AddComment(Comment c)
        { 
             _repo2.AddComment( c);
     
            return RedirectToAction("Product","Home",new { ProductId= c.ProductId });
        }

        public IActionResult Compare(Product product)
        {
            Product p = _repo.GetById(product.ProductID);
            CompareProduct.AddItem(p);
            return View( CompareProduct);
        }
        public IActionResult RemoveCompare(int productId )
        {
            Product product = CompareProduct.Lines.Where(c=>c.ProductID== productId).FirstOrDefault();
            if (product != null)
            {
                CompareProduct.RemoveLine(product);
            }
            if (CompareProduct.Lines.Count() != 0)
            {
                return View("Compare", CompareProduct);
            }
            
              return  RedirectToAction("index"); ;
            

        }

    }
}
