using MYShop.Domain.Contract.Repositories;
using MYShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MYShop.DAL.EF.Repositories
{
    public class EFProductPropertiesRepository : IProductPropertiesRepository
    {
        private readonly ApplicationContext _context;

        public EFProductPropertiesRepository(ApplicationContext context)
        {
            _context = context;
        }

        public ProductProperties DeleteProductProperties(int ProductPropertiesId)
        {
            throw new NotImplementedException();
        }

        public List<ProductProperties> Find(string query)
        {
            throw new NotImplementedException();
        }

        public List<ProductProperties> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<ProductProperties> GetById(int productid)
        {
            return _context.ProductProperties.Where(c => c.ProductId == productid).ToList();
        }

        public void SaveProductProperties(ProductProperties pp)
        {
            ProductProperties ProductProperties = _context.ProductProperties.Where(c=>c.ProductId==pp.ProductId && c.PropertyId==pp.PropertyId).FirstOrDefault();
            if (ProductProperties ==null)
            {
                _context.ProductProperties.Add(pp);
               
            }
            else
            {
                ProductProperties.Value = pp.Value;
            }
            _context.SaveChanges();
        }
    }
}
