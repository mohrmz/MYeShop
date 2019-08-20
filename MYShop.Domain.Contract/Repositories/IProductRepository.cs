
using MYShop.Domain.Entities;
using System.Collections.Generic;

namespace MYShop.Domain.Contract.Repositories
{
    public interface IProductRepository
    {
        List<Product> GetAll();

        List<Product> GetImages(int productid);
        List<Property> Getproperties(int CategoryId);
        Product GetById(int ProductId);
         Product FindById(int ProductId);
        PagedResult<Product> GetPagedData(int category, int pageNumber, string value, int PageSize);
        void SaveProduct(Product product);
       
        Product DeleteProduct(int productID);
        List<Product> Find(string query);
    }
}
