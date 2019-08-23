
using System.Collections.Generic;

namespace MYShop.Domain.Entities
{
    public class Category
    {
        public int CategoryID { get; set; }

        public int ParentId { get; set; }

        public int Clevel { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public bool IsDeleted { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();

        public List<Property> Properties { get; set; } = new List<Property>();

    }
}
