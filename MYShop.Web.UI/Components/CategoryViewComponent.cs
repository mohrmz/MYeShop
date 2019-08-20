using Microsoft.AspNetCore.Mvc;
using MYShop.Domain.Contract.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MYShop.Web.UI.Components
{
    public class CategoryViewComponent:ViewComponent
    {
        private readonly ICategoryRepository _repo;
        public CategoryViewComponent(ICategoryRepository repo)
        {
            _repo = repo;
        }
        public IViewComponentResult Invoke()
        {
            return View("View",_repo.GetAll());
        }
    }
}
