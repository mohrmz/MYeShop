using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MYShop.Domain.Entities
{
    public class ProductImages
    {
        public int ID { get; set; }

        public int ProductId { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string PicAlt { get; set; }
        public byte[] Image { get; set; }

        public Product Product { get; set; }
    }
}
