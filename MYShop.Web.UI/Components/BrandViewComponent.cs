using Microsoft.AspNetCore.Mvc;
using MYShop.Domain.Contract.Repositories;
using MYShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MYShop.Web.UI.Components
{
    public class BrandViewComponent : ViewComponent
    {
        private readonly IBrandRepository _repo;
      
        public BrandViewComponent(IBrandRepository repo)
        {
            _repo = repo;
            
        }
        
        public IViewComponentResult Invoke()
        {         
            return View("View",_repo.GetBrands());
        }
    }
}