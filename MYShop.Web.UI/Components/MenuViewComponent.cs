using Microsoft.AspNetCore.Mvc;
using MYShop.Domain.Contract.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MYShop.Web.UI.Components
{
    public class MenuViewComponent : ViewComponent
    {
        private readonly IBrandRepository _repo1;
        private readonly ICategoryRepository _repo;
        private readonly IProductRepository _repo2;
        public MenuViewComponent(ICategoryRepository repo, IBrandRepository repo1, IProductRepository repo2)
        {
            _repo = repo;
            _repo1 = repo1;
            _repo2 = repo2;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.brand = _repo1.GetBrands();
            ViewBag.products = _repo2.GetAll();
            return View("View", _repo.GetAll());
        }
    }
}
