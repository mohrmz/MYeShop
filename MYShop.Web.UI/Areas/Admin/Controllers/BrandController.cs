using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MYShop.Domain.Contract.Repositories;
using MYShop.Domain.Entities;

namespace MYShop.Web.UI.Areas.Admin.Controllers
{
    [Area("admin")]
    //[Authorize]
    public class BrandController : Controller
    {
        private readonly IBrandRepository _brandRepository;

        public BrandController(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public IActionResult Index()
        {
            return View(_brandRepository.GetAll());
        }

        public IActionResult Create()
        {
            return View("Edit", new Brand());
        }
        public ViewResult Edit(int id)
        {
            var result = _brandRepository.GetById(id);
            return View(result);
        }
        [HttpPost]
        public IActionResult Edit(Brand brand, IFormFile files)
        {
            if (files?.Length > 0)
            {

               
                        using (var ms = new MemoryStream())
                        {
                            files.CopyToAsync(ms);
                            var fileBytes = ms.ToArray();
                    brand.BrandIco = fileBytes;
                        }
                    
                
            }
            if (ModelState.IsValid)
            {
                _brandRepository.SaveBrand(brand);
                TempData["message"] = $"{brand.Name} ذخیره شد";
                return RedirectToAction("Index");
            }
            else
            {
                return View(brand);
            }
        }
        public IActionResult Delete(int id)
        {
            _brandRepository.DeleteBrand(id);
            TempData["message"] = $"حذف با موفقیت انجام شد";
            return RedirectToAction("Index");
        }
        public IActionResult Find(string term)
        {
            var result = _brandRepository.Find(term);

            return Json(new { results = (result.Select(c => new { id = c.BrandID, text = c.Name })) });
        }
    }
}