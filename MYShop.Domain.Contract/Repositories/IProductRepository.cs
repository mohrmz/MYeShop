
using MYShop.Domain.Entities;
using System.Collections.Generic;

namespace MYShop.Domain.Contract.Repositories
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        List<Product> GetNews();
        List<Product> GetDiscount();
       
        List<Brand> GetBrands();
        List<Product> GetImages(int productid);
        List<Property> Getproperties(int CategoryId);
        List<Product> Getbycategory(int CategoryId);
        List<Category> GetAllCategories();
        Product GetById(int ProductId);
        Product FindById(int ProductId);
        PagedResult<Product> GetPagedData(int category, int pageNumber, string value, int PageSize);
        void SaveProduct(Product product);
       
        Product DeleteProduct(int productID);
        List<Product> Find(string query);
    }
}
