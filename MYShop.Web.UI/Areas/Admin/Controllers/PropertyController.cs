using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MYShop.Domain.Contract.Repositories;
using MYShop.Domain.Entities;
using Microsoft.AspNetCore.Http;
namespace MYShop.Web.UI.Areas.Admin.Controllers
{
    [Area("admin")]
    [Authorize]
    public class PropertyController : Controller
    {
        
        private readonly IPropertyRepository _propertyRepository;

        public PropertyController(IPropertyRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }

        public IActionResult Index()
        {
         return View(_propertyRepository.GetRoot(0));
        }
        public IActionResult Index2(int parentid,int categoryid)
        {
            ViewData["parentid"] = parentid;
            ViewData["categoryid"] = categoryid;
            return View(_propertyRepository.GetNode(parentid));
        }
        public IActionResult Create(int parentid,int categoryid)
        {
            Property p = new Property();
            p.ParentId = parentid;
            p.CategoryId = categoryid;
            return View("Edit", p);
        }
        public ViewResult Edit(int id)
        {
            var result = _propertyRepository.GetById(id);
            return View(result);
        }
        [HttpPost]
        public IActionResult Edit(Property Property)
        {
            
            if (ModelState.IsValid)
            {
                _propertyRepository.SaveProperty(Property);
                TempData["message"] = $"{Property.Name} ذخیره شد";
                return RedirectToAction("index");
            }
            else
            {
                return View(Property);
            }
        }
        public IActionResult Delete(int id)
        {
            _propertyRepository.DeleteProperty(id);
            TempData["message"] = $"حذف با موفقیت انجام شد";
            return RedirectToAction("Index");
        }
    }
}