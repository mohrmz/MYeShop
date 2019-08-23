using MYShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MYShop.Domain.Contract.Repositories
{
    public interface IBrandRepository
    {
        List<Brand> GetAll();
        void SaveBrand(Brand Brand);
        Brand DeleteBrand(int BrandID);
        Brand GetById(int BrandId);
        List<Brand> Find(string query);
        List<Brand> GetBrands();
    }
}
