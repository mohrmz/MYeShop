using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYShop.Domain.Contract.Repositories;
using MYShop.Domain.Entities;

namespace MYShop.DAL.EF.Repositories
{
    public class EFProductImagesRepository: IProductImages
    {
        private ApplicationContext _context;

        public EFProductImagesRepository(ApplicationContext context)
        {
            this._context = context;
        }

        public ProductImages DeleteProductImages(int ProductImagesID)
        {
            ProductImages dbEntry = _context.ProductImages.FirstOrDefault(p => p.ID == ProductImagesID);
            if (dbEntry != null)
            {
                _context.ProductImages.Remove(dbEntry);
                _context.SaveChanges();
            }
            return dbEntry;
        }

        public List<ProductImages> Find(string query)
        {
            throw new NotImplementedException();
        }

        public List<ProductImages> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<ProductImages> GetById(int ProductId)
        {
            return _context.ProductImages.Where(c => c.ProductId == ProductId).ToList();
        }

        public ProductImages GetPhotoId(int Id)
        {
            return _context.ProductImages.Where(c => c.ID == Id).FirstOrDefault();
        }

        public void SaveProductImages(ProductImages ProductImages)
        {
            if (ProductImages.ID == 0)
            {
                _context.ProductImages.Add(ProductImages);
            }
            else
            {
                ProductImages dbEntry = _context.ProductImages
                .FirstOrDefault(p => p.ID == ProductImages.ID);
                if (dbEntry != null)
                {
                    
                    dbEntry.Image = ProductImages.Image;

                }
            }
            _context.SaveChanges();
        }
    }
}
