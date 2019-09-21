using Microsoft.AspNetCore.Mvc;
using MYShop.Domain.Contract.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MYShop.Web.UI.Components
{
    public class PropertyViewComponent : ViewComponent
    {
        private readonly IProductRepository _repo;
        private readonly IPropertyRepository _repo1;
        public PropertyViewComponent(IProductRepository repo, IPropertyRepository repo1)
        {
            _repo = repo;
            _repo1 = repo1;
        }
        public IViewComponentResult Invoke(int propductid,int CategoryId,bool isshort)
        {
            ViewBag.Property = _repo1.GetRoot(CategoryId, isshort);
            return View("View", _repo.FindById(propductid));
        }
    }
}
