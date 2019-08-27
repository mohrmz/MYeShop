
using MYShop.Domain.Entities;
using System.Collections.Generic;

namespace MYShop.Domain.Contract.Repositories
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        List<Price> GetPrices(Product p);
        List<ProductColor> GetAllColor(Product p);
        List<Product> GetNews();
        List<Product> GetDiscount();
       
        List<Product> GetImages(int productid);
        List<Property> Getproperties(int CategoryId);
        List<Product> Getbycategory(int CategoryId);
        List<Category> GetAllCategories();
        Product GetById(int ProductId);
        Price GetPriceById(int ProductId);
        ProductColor GetColorById(int ColorId);
        Product FindById(int ProductId);
        PagedResult<Product> GetPagedData(int category, int pageNumber, string value, int PageSize);
        void SaveProduct(Product product);
        void SavePrice(Price Price);

        void SaveColor(ProductColor ProductColor);
        Product DeleteProduct(int productID);

        Price DeletePrice(int priceid);
        ProductColor DeleteColor(int Colorid);
        List<Product> Find(string query);
        List<ProductColor> FindProductColor(string query, int ProductID);
    }
}
