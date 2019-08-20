using System;
using System.Collections.Generic;

namespace MYShop.Domain.Entities
{
    public class Product
    {
        public int ProductID { get; set; }
        public int BrandID { get; set; }
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Guarantee { get; set; }
        public byte[] Image { get; set; }
        public Int64 Price { get; set; }
        public bool IsDeleted { get; set; }
        public Category Category { get; set; }
        public Brand Brand { get; set; }
        public int discount { get; set; }
        public int newvalue { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<ProductImages> ProductImages { get; set; } 
        public ICollection<ProductProperties> ProductProperties { get; set; }
    }
    
}
