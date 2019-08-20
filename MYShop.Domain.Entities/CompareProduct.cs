using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MYShop.Domain.Entities
{
    public class CompareProduct
    {

        private List<Product> ProductCollection = new List<Product>();

        public virtual void AddItem(Product product)
        {
            Product line = ProductCollection
          .Where(p => p.ProductID == product.ProductID)
          .FirstOrDefault();
            if (line == null && Lines.Count()<4)
            {
                ProductCollection.Add(product);
            }
           
        }
      
        public virtual void RemoveLine(Product product) =>
        ProductCollection.Remove(product);
        public virtual decimal ComputeTotalValue() =>
            ProductCollection.Count();
        public virtual void Clear() => ProductCollection.Clear();
        public virtual IEnumerable<Product> Lines => ProductCollection;
    }
}

