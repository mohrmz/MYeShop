﻿using MYShop.Domain.Contract.Repositories;
using MYShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MYShop.DAL.EF.Repositories
{
    public class EFCategoryRepository : ICategoryRepository
    {
        private readonly ApplicationContext _context;

        public EFCategoryRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Category DeleteCategory(int CategoryID)
        {
            Category dbEntry = _context.Categories.FirstOrDefault(p => p.CategoryID == CategoryID);
            if (dbEntry != null)
            {
                dbEntry.IsDeleted = true;
                _context.SaveChanges();
            }
            return dbEntry;
        }

        public List<Category> GetAll()
        {
            return _context.Categories.ToList();
        }

        public void SaveCategory(Category category)
        {
            if (category.CategoryID == 0)
            {
                _context.Categories.Add(category);
            }
            else
            {
                Category dbEntry = _context.Categories
                .FirstOrDefault(p => p.CategoryID == category.CategoryID);
                if (dbEntry != null)
                {
                    dbEntry.Name = category.Name;
                    dbEntry.ParentId = category.ParentId;
                    dbEntry.Image = category.Image;
                    dbEntry.Clevel = category.Clevel;
                }
            }
            _context.SaveChanges();
        }
        public Category GetById(int CategoryId)
        {
            return _context.Categories.Find(CategoryId);
        }

        public List<Category> Find(string query)
        {
            return _context.Categories.
                Where(c => c.Name.StartsWith(query)).OrderBy(c => c.Name).Take(10).ToList();
        }

        public List<Category> GetNode(int ParentID)
        {
            return _context.Categories.Where(c => c.ParentId == ParentID).ToList();
        }

        public List<Category> GetRoot()
        {
            return _context.Categories.Where(c => c.ParentId == 0).ToList();
        }

        public List<Category> GetAllClevel(int clevel)
        {
            return _context.Categories.Where(c=>c.Clevel==clevel).ToList();
        }

    }
}

