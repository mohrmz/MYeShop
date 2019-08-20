using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MYShop.Domain.Entities
{
    public class ProductProperties
    {
        public int ProductId { get; set; }
        public int PropertyId { get; set; }
        public string Value { get; set; }
        public Product Product { get; set; }
        public Property Property { get; set; }
    }
}
