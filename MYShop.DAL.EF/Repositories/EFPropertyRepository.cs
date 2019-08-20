using MYShop.Domain.Contract.Repositories;
using MYShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MYShop.DAL.EF.Repositories
{
    public class EFPropertyRepository : IPropertyRepository
    {
        private readonly ApplicationContext _context;

        public EFPropertyRepository(ApplicationContext context)
        {
            _context = context;
        }

    
        public void  DeleteProperty(int PropertyID)
        {
            List<Property> properties = _context.Properties.Where(p => p.PropertyID == PropertyID|| p.ParentId == PropertyID).ToList();
            foreach (Property p in properties)
            {
                _context.Properties.Remove(p);
                _context.SaveChanges();
            }
            
        }

        public List<Property> GetAll()
        {
            return _context.Properties.ToList();
        }

        public Property GetById(int PropertyID)
        {
            return _context.Properties.Find(PropertyID);
        }

        public List<Property> GetNode(int ParentID)
        {
            return _context.Properties.Where(c => c.ParentId == ParentID).ToList();
        }

        public List<Property> GetRoot(int CategoryId)
        {
            return _context.Properties.Where(c=>c.ParentId==0 && (c.CategoryId==CategoryId||CategoryId==0)).ToList();
        }

        public void SaveProperty(Property Property)
        {
            if (Property.PropertyID == 0)
            {
                _context.Properties.Add(Property);
            }
            else
            {
                Property dbEntry = _context.Properties
                .FirstOrDefault(p => p.PropertyID == Property.PropertyID );
                if (dbEntry != null)
                {
                    dbEntry.CategoryId = Property.CategoryId;
                    dbEntry.Name = Property.Name;
                    dbEntry.ParentId = Property.ParentId;

                }
            }
            _context.SaveChanges();
        }

    }
}
