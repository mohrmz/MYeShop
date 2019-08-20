using System;
using System.Collections.Generic;
using System.Text;

namespace MYShop.Domain.Entities
{
    public class Property
    {
        public int PropertyID { get; set; }
        public string Name { get; set; }
        public int ParentId { get; set; }

        public int CategoryId { get; set; }

        public bool IsDeleted { get; set; }
        public Category Category { get; set; }

        public ICollection<ProductProperties> ProductProperties { get; set; } 
    }
}
