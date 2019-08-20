using MYShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MYShop.Domain.Contract.Repositories
{
    public interface IProductPropertiesRepository
    {
        List<ProductProperties> GetAll();
        List<ProductProperties> GetById(int productid);
        void SaveProductProperties(ProductProperties ProductProperties);
        ProductProperties DeleteProductProperties(int ProductPropertiesId);
        List<ProductProperties> Find(string query);
    }
}
