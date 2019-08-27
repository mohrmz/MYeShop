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
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index(int parentid=0)
        
{
            
            ViewData["parentid"] = parentid;
            return View(_categoryRepository.GetNode(parentid));
        }
        public IActionResult Delete(int id)
        {
            _categoryRepository.DeleteCategory(id);
            TempData["message"] = $"حذف با موفقیت انجام شد";
            return RedirectToAction("Index");
        }
        public IActionResult Index2(int parentid)
        {
            ViewData["parentid"] = parentid;
            return View(_categoryRepository.GetNode(parentid));
        }
        public IActionResult Index3(int parentid)
        {
            ViewData["parentid"] = parentid;
            return View(_categoryRepository.GetNode(parentid));
        }
        public IActionResult Create(int parentid,int Clevel)
        {
            Category p = new Category();
            p.ParentId = parentid;
            p.Clevel = Clevel;
            return View("Edit", p);
        }
        public ViewResult Edit(int id)
        {
            var result = _categoryRepository.GetById(id);
            return View(result);
        }
        [HttpPost]
        public IActionResult Edit(Category category, IFormFile files)
        {
            if (files?.Length > 0)
            {


                using (var ms = new MemoryStream())
                {
                    files.CopyToAsync(ms);
                    var fileBytes = ms.ToArray();
                    category.Image = fileBytes;
                }


            }
            if (ModelState.IsValid)
            {
                _categoryRepository.SaveCategory(category);
                TempData["message"] = $"{category.Name} ذخیره شد";
                return RedirectToAction("Index");
            }
            else
            {
                return View(category);
            }
        }
        public IActionResult Find(string term)
        {
            var result = _categoryRepository.Find(term);

            return Json(new { results = (result.Select(c => new { id = c.CategoryID, text = c.Name })) });
        }
        public IActionResult Findcategoryprice(string term,int categoryId)
        {
            var result = _categoryRepository.FindCategoryPrice(term,categoryId);

            return Json(new { results = (result.Select(c => new { id = c.CategoryPriceID, text = c.Value })) });
        }
        public IActionResult ListCategoryPrice(Category c)
        {
           var result = _categoryRepository.ListCategoryPrice(c);
            ViewBag.CategoryId = c.CategoryID;
            return View(result);
        }
        public IActionResult Createcategoryprice(int CategoryId)
        {
            CategoryPrice p = new CategoryPrice();
            p.CategoryId = CategoryId;
            return View("Editcategoryprice", p);
        }
        public ViewResult Editcategoryprice(int Editcategoryprice)
        {
            var result = _categoryRepository.GetCategoryPriceById(Editcategoryprice);
            return View(result);
        }
        [HttpPost]
        public IActionResult Editcategoryprice(CategoryPrice category)
        {
           
                _categoryRepository.SaveCategoryPrice(category);
                TempData["message"] = $"{category.Value} ذخیره شد";
                return RedirectToAction("Index");
           
        }
    }
}