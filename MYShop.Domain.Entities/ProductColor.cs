using System;
using System.Collections.Generic;
using System.Text;

namespace MYShop.Domain.Entities
{
    public class ProductColor
    {
        public int ProductColorID { get; set; }

        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public bool IsDeleted { get; set; }
        public Product Product { get; set; }
    }
}
