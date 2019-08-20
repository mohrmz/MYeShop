using MYShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MYShop.Web.UI.Models
{
    public class HomeViewModel
    {
        public int Category { get; set; }
        public PagedResult<Product> Result { get; set; } = new PagedResult<Product>();
    }
}
