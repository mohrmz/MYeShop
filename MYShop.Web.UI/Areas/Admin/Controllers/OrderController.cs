using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MYShop.Domain.Contract.Repositories;
using MYShop.Domain.Entities;

namespace MYShop.Web.UI.Areas.Admin.Controllers
{
    [Area("admin")]
    [Authorize]
    public class OrderController : Controller
    {
        private IOrderRepository repository;

        public OrderController(IOrderRepository repoService)
        {
            repository = repoService;

        }
        public ViewResult NewOrders() => View(repository.GetList(false));
        [HttpPost]
        public IActionResult MarkShipped(int orderID)
        {
            Order order = repository.GetById(orderID);
            if (order != null)
            {
                order.Shipped = true;
                repository.SaveOrder(order);
            }
            return RedirectToAction(nameof(NewOrders));
        }
        public IActionResult NewOrderList()
        {
            return View();
        }
    }
}