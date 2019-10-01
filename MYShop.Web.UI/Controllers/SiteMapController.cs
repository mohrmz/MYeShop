using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fluent.Infrastructure.FluentModel;
using Microsoft.AspNetCore.Mvc;
using MYShop.Web.UI.Models;

namespace MYShop.Web.UI.Controllers
{
    public class SiteMapController : Controller
    {
        private readonly ApplicationDbContext _db;
        public SiteMapController(ApplicationDbContext db)
        {
            _db = db;
        }

       
    }
}