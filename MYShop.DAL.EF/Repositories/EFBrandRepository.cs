using MYShop.Domain.Contract.Repositories;
using MYShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MYShop.DAL.EF.Repositories
{
    public class EFBrandRepository : IBrandRepository
    {
        private readonly ApplicationContext _context;

        public EFBrandRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Brand DeleteBrand(int BrandID)
        {
            Brand dbEntry = _context.Brands.FirstOrDefault(p => p.BrandID == BrandID);
            if (dbEntry != null)
            {
                dbEntry.IsDeleted = true;
                _context.SaveChanges();
            }
            return dbEntry;
        }

      

        public List<Brand> GetAll()
        {
            return _context.Brands.ToList();
        }

        public Brand GetById(int BrandId)
        {
            return _context.Brands.Find(BrandId);
        }

        public void SaveBrand(Brand Brand)
        {
            if (Brand.BrandID == 0)
            {
                _context.Brands.Add(Brand);
            }
            else
            {
                Brand dbEntry = _context.Brands
                .FirstOrDefault(p => p.BrandID == Brand.BrandID);
                if (dbEntry != null)
                {
                    dbEntry.Name = Brand.Name;
                    dbEntry.BrandIco = Brand.BrandIco;
                    dbEntry.hovercolor = Brand.hovercolor;
                }
            }
            _context.SaveChanges();
        }

        public List<Brand> Find(string query)
        {
            return _context.Brands.
                Where(c => c.Name.StartsWith(query)).OrderBy(c => c.Name).Take(10).ToList();
        }
    }
}
