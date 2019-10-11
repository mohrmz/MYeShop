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
            return _context.Products.Include(c => c.Brand).Include(f => f.Category).Include(k => k.Comments).Include(g => g.ProductProperties).ThenInclude(s=>s.Property).Include(h => h.ProductImages).Include(t=>t.Prices).Where(d => d.ProductID == ProductId).FirstOrDefault();
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
                    dbEntry.Audio = product.Audio;
                    dbEntry.Video = product.Video;
                    dbEntry.Title = product.Title;
                    dbEntry.ShortDescription = product.ShortDescription;
                    dbEntry.Keywords = product.Keywords;
                    dbEntry.newvalue = product.newvalue;
                    dbEntry.discount = product.discount;
                    dbEntry.Guarantee = product.Guarantee;
                    dbEntry.Facebook = product.Facebook;
                    dbEntry.Twitter = product.Twitter;
                    dbEntry.Instagram = product.Instagram;
                    dbEntry.Pinteret = product.Pinteret;
                    dbEntry.WikiPedia = product.WikiPedia;
                    dbEntry.BrandID = product.BrandID;
                    dbEntry.CategoryID = product.CategoryID;
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
            return _context.Products.Where(c => c.discount!=0).Take(15).ToList();
        }

        public List<Brand> GetBrands()
        {
            return _context.Brands.Include(c=>c.Products).Take(15).ToList();
        }

        public List<Price> GetPrices(Product p)
        {
            return _context.Price.Where(c=>c.ProductID==p.ProductID).ToList();
        }
        public Price GetPriceById(int ProductId)
        {
           return _context.Price.Find(ProductId);
        }
        public void SavePrice(Price product)
        {
            if (product.PriceID == 0)
            {
                _context.Price.Add(product);
            }
            else
            {
                Price dbEntry = _context.Price
                .FirstOrDefault(p => p.PriceID == product.PriceID);
                if (dbEntry != null)
                {
                    dbEntry.Value = product.Value;
                    dbEntry.NewValue = product.NewValue;
                    dbEntry.Discount = product.Discount;
                    dbEntry.DateF = product.DateF;
                    dbEntry.DateT = product.DateT;
                    dbEntry.ProductColorID = product.ProductColorID;
                    dbEntry.CategoryPriceID = product.CategoryPriceID;
                }
            }
            _context.SaveChanges();
        }

        public Price DeletePrice(int priceid)
        {
            Price dbEntry = _context.Price.FirstOrDefault(p => p.PriceID == priceid);
            if (dbEntry != null)
            {
                dbEntry.IsDeleted = true;
                _context.SaveChanges();
            }
            return dbEntry;
        }

        public List<ProductColor> GetAllColor(Product p)
        {
            return _context.ProductColors.Where(c => c.ProductID == p.ProductID).ToList();
        }

        public ProductColor GetColorById(int ColorId)
        {
            return _context.ProductColors.Find(ColorId);
        }

        public void SaveColor(ProductColor ProductColor)
        {
            if (ProductColor.ProductColorID == 0)
            {
                _context.ProductColors.Add(ProductColor);
            }
            else
            {
                ProductColor dbEntry = _context.ProductColors
                .FirstOrDefault(p => p.ProductColorID == ProductColor.ProductColorID);
                if (dbEntry != null)
                {
                    dbEntry.Value = ProductColor.Value;
                    dbEntry.Name = ProductColor.Name;
                    
                }
            }
            _context.SaveChanges();
        }

        public ProductColor DeleteColor(int Colorid)
        {
            ProductColor dbEntry = _context.ProductColors.FirstOrDefault(p => p.ProductColorID == Colorid);
            if (dbEntry != null)
            {
                dbEntry.IsDeleted = true;
                _context.SaveChanges();
            }
            return dbEntry;
        }

        public List<ProductColor> FindProductColor(string query, int ProductID)
        {
            return _context.ProductColors.
                Where(c => c.Name.StartsWith(query)).Where(f=>f.ProductID== ProductID).OrderBy(c => c.Name).Take(10).ToList();
        }

        public List<CategoryPrice> GetCategoryPrice(int categoryId)
        {
            return _context.CategoryPrice.Where(c => c.CategoryId == categoryId).ToList();
        }
    }
}
