using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MYShop.Domain.Contract.Repositories;
using MYShop.Domain.Entities;

namespace MYShop.Web.UI.Areas.Admin.Controllers
{
    [Area("admin")]
    //[Authorize]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductPropertiesRepository _ProductPropertiesRepository;
        private readonly IProductImages _ProductImages;

        IHostingEnvironment _env;
        public ProductController(IProductRepository productRepository, IProductPropertiesRepository ProductPropertiesRepository, IProductImages ProductImages, IHostingEnvironment env)
        {
            _productRepository = productRepository;
            _ProductPropertiesRepository = ProductPropertiesRepository;
            _ProductImages = ProductImages;
            _env = env;
        }
        public IActionResult Index()
        {
            return View(_productRepository.GetAll());
        }

        public IActionResult photos(int productid)
        {
            @ViewData["productid"] = productid;
            return View(_ProductImages.GetById(productid));
        }

        public IActionResult Addpropery(int categoryid,int ProductId)
        {
            ViewBag.Addpropery = _productRepository.Getproperties(categoryid);
            ViewBag.ProductId = ProductId;

            return View();
        }
        [HttpPost]
        public IActionResult Addpropery(IFormCollection fc,ProductProperties pp)
        {
            

            foreach(var item in fc.Keys.Where(c=>c.ToString()!= "__RequestVerificationToken"))
            {

                ProductProperties productProperties = new ProductProperties();
                productProperties.ProductId = pp.ProductId;
                string pid = item.ToString();
                productProperties.PropertyId = Int32.Parse(item.ToString());
                productProperties.Value = fc[item.ToString()].ToString();

                _ProductPropertiesRepository.SaveProductProperties(productProperties);

            }
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View("Edit", new Product());
        }
        public IActionResult Createphoto(int productid)
        {

            ProductImages p = new ProductImages();
            p.ProductId = productid;
           

            return View("Editphoto", p);
        }
        public ViewResult Editphoto(int id)
        {
            var result = _ProductImages.GetById(id);
            return View(result);
        }
        [HttpPost]
        public IActionResult Editphoto(ProductImages product, IFormFile files)
        {
            if (files?.Length > 0)
            {


                using (var ms = new MemoryStream())
                {
                    files.CopyToAsync(ms);
                    var fileBytes = ms.ToArray();
                    product.Image = fileBytes;
                }


            }
            if (ModelState.IsValid)
            {
                _ProductImages.SaveProductImages(product);
                TempData["message"] = $" ذخیره شد";
                return RedirectToAction("photos", "Product", new { productid= product.ProductId });
            }
            else
            {
                return View(product);
            }
        }
        public IActionResult Deletephoto(int id,int productid)
        {
            _ProductImages.DeleteProductImages(id);
            TempData["message"] = $"حذف با موفقیت انجام شد";
            return RedirectToAction("photos", "Product", new { productid  });
        }
        public ViewResult Edit(int id)
        {
            var result = _productRepository.GetById(id);
            return View(result);
        }
        [HttpPost]
        public IActionResult Edit(Product product, IFormFile files)
        {
            if (files?.Length > 0)
            {


                using (var ms = new MemoryStream())
                {
                    files.CopyToAsync(ms);
                    var fileBytes = ms.ToArray();
                    product.Image = fileBytes;
                }


            }
            if (ModelState.IsValid)
            {
                _productRepository.SaveProduct(product);
                TempData["message"] = $"{product.Name} ذخیره شد";
                return RedirectToAction("Index");
            }
            else
            {
                return View(product);
            }
        }
        public IActionResult Delete(int id)
        {
            _productRepository.DeleteProduct(id);
            TempData["message"] = $"حذف با موفقیت انجام شد";
            return RedirectToAction("Index");
        }

    }
}