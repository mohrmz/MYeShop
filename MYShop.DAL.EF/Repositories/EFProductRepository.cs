using Microsoft.EntityFrameworkCore;
using MYShop.Domain.Contract.Repositories;
using MYShop.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MYShop.DAL.EF.Repositories
{
    public class EfProductRepository : IProductRepository
    {
        private readonly ApplicationContext _context;
        public EfProductRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Product DeleteProduct(int productID)
        {
            Product dbEntry = _context.Products.FirstOrDefault(p => p.ProductID == productID);
            if (dbEntry != null)
            {
                dbEntry.IsDeleted = true;
                _context.SaveChanges();
            }
            return dbEntry;
        }

        public List<Product> Find(string query)
        {
            return _context.Products.
                Where(c => c.Name.StartsWith(query)).OrderBy(c => c.Name).Take(10).ToList();
        }

        public List<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public List<Category> GetAllCategories()
        {
            return _context.Products.Select(c=>c.Category).Distinct().ToList();
        }
        public List<Product> Getbycategory(int categoryid)
        {
            return _context.Products.Where(c=>c.CategoryID == categoryid).Include(c=>c.Brand).Include(g=>g.Category).Take(15).ToList();
        }

        public Product GetById(int ProductId)
        {
            //return _context.Products.Include(c => c.Brand).Include(f => f.Category).Include(g => g.ProductProperties).Include(h => h.ProductImages).Where(d => d.ProductID == ProductId).FirstOrDefault();
            return _context.Products.Find(ProductId) ;
        }
        public Product FindById(int ProductId)
        {
            return _context.Products.Include(c => c.Brand).Include(f => f.Category).Include(k => k.Comments).Include(g => g.ProductProperties).ThenInclude(s=>s.Property).Include(h => h.ProductImages).Where(d => d.ProductID == ProductId).FirstOrDefault();
            //return _context.Products.Find(ProductId);
        }

        public PagedResult<Product> GetPagedData(int category, int pageNumber, string value, int PageSize)
        {
            var query = _context.Products.Include(c => c.Brand).Where(c => (category==0 || c.CategoryID == category) && (string.IsNullOrEmpty(value)||c.Name.StartsWith(value)||c.Brand.Name.StartsWith(value)||c.Category.Name.StartsWith(value)));
            PagedResult<Product> result = new PagedResult<Product>();
            result.pagingData.CurrentPage = pageNumber;
            result.pagingData.ItemsPerPage = PageSize;
            result.pagingData.TotalItems = query.Count();
            result.Items = query.OrderBy(c => c.ProductID).
                Skip((pageNumber - 1) * PageSize).Take(PageSize).
                ToList();
            return result;
        }


        public List<Property> Getproperties(int categoryId)
        {
           return _context.Properties.Where(c => c.CategoryId == categoryId).ToList();
        }

        public List<Product> GetImages(int productid)
        {
            return _context.Products.Include(c=>c.ProductImages).Where(c=>c.ProductID==productid).ToList();
        }

        public void SaveProduct(Product product)
        {
            if (product.ProductID == 0)
            {
                _context.Products.Add(product);
            }
            else
            {
                Product dbEntry = _context.Products
                .FirstOrDefault(p => p.ProductID == product.ProductID);
                if (dbEntry != null)
                {
                    dbEntry.Name = product.Name;
                    dbEntry.Description = product.Description;
                    dbEntry.Price = product.Price;
                    dbEntry.Name = product.Name;
                    dbEntry.Image= product.Image;
                }
            }
            _context.SaveChanges();
        }

        public List<Product> GetNews()
        {
            return _context.Products.OrderByDescending(c=>c.ProductID).Take(15).ToList();
        }

        public List<Product> GetDiscount()
        {
            return _context.Products.OrderByDescending(c => c.discount!=0).Take(15).ToList();
        }

        public List<Brand> GetBrands()
        {
            return _context.Brands.Include(c=>c.Products).Take(15).ToList();
        }
    }
}
