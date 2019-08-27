using System;
using System.Collections.Generic;
using System.Text;

namespace MYShop.Domain.Entities
{
   public class CategoryPrice
    {
        public int CategoryPriceID { get; set; }
        public int CategoryId { get; set; }

        public string Value { get; set; }

        public Category Category { get; set; }

        public List<Price> listPrice { get; set; } = new List<Price>();

    }
}
