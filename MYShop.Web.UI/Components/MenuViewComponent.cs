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
        private readonly ICategoryRepository _repo;
        public MenuViewComponent(ICategoryRepository repo)
        {
            _repo = repo;
        }
        public IViewComponentResult Invoke()
        {

            return View("View", _repo.GetAll());
        }
    }
}
