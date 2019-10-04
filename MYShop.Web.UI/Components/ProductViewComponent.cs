using Microsoft.AspNetCore.Mvc;
using MYShop.Domain.Contract.Repositories;
using MYShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MYShop.Web.UI.Components
{
    public class ProductViewComponent : ViewComponent
    {
        private readonly IProductRepository _repo;
        private readonly ICategoryRepository _repo1;
        public ProductViewComponent(IProductRepository repo,ICategoryRepository repo1)
        {
            _repo = repo;
            _repo1 = repo1;
        }
        List<Product> products;
        public IViewComponentResult Invoke(Category category,int type)
        {
            
            if (type==1)
            {
                products = _repo.Getbycategory(category.CategoryID);
                ViewBag.pname = _repo1.GetById(category.ParentId).Name + " " + category.Name;
            }
            else if (type==2)
            {
                products = _repo.GetNews();
                ViewBag.pname = "جدید ترین ها";
            }
            else if (type == 3)
            {
                products = _repo.GetDiscount();
                ViewBag.pname = "تخفیف";
            }
            else if (type == 4)
            {
                products = _repo.GetNews();
                ViewBag.pname = "مناسب برای شما";
            }
            return View("View", products);
        }
    }
}
