using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MYShop.Domain.Entities
{
    public class Product
    {
        public int ProductID { get; set; }
        public int BrandID { get; set; }

        public int CategoryID { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string Name { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string Title { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string ShortDescription { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string Description { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string Keywords { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string Facebook { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string Twitter { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string Instagram { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string Pinteret { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string WikiPedia { get; set; }
        public string Guarantee { get; set; }
        public byte[] Image { get; set; }
        public byte[] Audio { get; set; }
        public byte[] Video { get; set; }
        public Int64 Price { get; set; }
        public bool IsDeleted { get; set; }
        public Category Category { get; set; }
        public Brand Brand { get; set; }
        public int discount { get; set; }
        public int newvalue { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<ProductImages> ProductImages { get; set; } 
        public ICollection<ProductProperties> ProductProperties { get; set; }
        public ICollection<Price> Prices { get; set; }
        public ICollection<ProductColor> ProductColor { get; set; }
     

    }
    
}
