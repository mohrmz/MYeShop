using MYShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MYShop.Domain.Contract.Repositories
{
    public interface IProductImages
    {
        List<ProductImages> GetAll();
        void SaveProductImages(ProductImages ProductImages);
        ProductImages DeleteProductImages(int ProductImagesID);
        List<ProductImages> GetById(int ProductId);
        ProductImages GetPhotoId(int Id);

        List<ProductImages> Find(string query);
    }
}
