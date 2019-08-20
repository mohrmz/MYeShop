
using System.Collections.Generic;

namespace MYShop.Domain.Entities
{
    public class Brand
    {
        public int BrandID { get; set; }

        public string Name { get; set; }

        public byte[] BrandIco { get; set; }

        public string hovercolor { get; set; }
        public bool IsDeleted { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();

    }
}
