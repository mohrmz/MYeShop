using Microsoft.AspNetCore.Mvc;
using MYShop.Domain.Contract.Repositories;
using MYShop.Domain.Entities;
using MYShop.Web.UI.Models;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

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
        [Route("/sitemap.xml")]
        public IActionResult Sitemap()
        {

            string data = System.IO.File.ReadAllText("/wwwroot/sitemap.xml", Encoding.UTF8);
            return Content(data, "text/xml");
        }
        [Route("/Robots.txt")]
        public IActionResult Robot()
        {

            string data = System.IO.File.ReadAllText("/wwwroot/robots.txt", Encoding.UTF8);
            return Content(data, "text/plain");
        }
        [Route("/manifest.json")]
        public IActionResult manifest()
        {

            string data = System.IO.File.ReadAllText("/wwwroot/manifest.json", Encoding.UTF8);
            return Content(data, "text/json");
        }
        public IActionResult Index(int CategoryId,int ProductID, string value, int page =1)
        {

            ViewBag.bb = _repo.GetAllCategories();
            HomeViewModel model = new HomeViewModel();
            model.Category = CategoryId;
            model.Result = _repo.GetPagedData(CategoryId,ProductID, page, value, pagesize);
            return View(model);
        }
        public IActionResult Product(Product product)
        {
            var result = _repo.FindById(product.ProductID);
            ViewBag.categoryprice = _repo.GetCategoryPrice(result.CategoryID);
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
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
