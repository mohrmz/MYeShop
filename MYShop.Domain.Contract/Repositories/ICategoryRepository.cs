using MYShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MYShop.Domain.Contract.Repositories
{
    public interface ICategoryRepository
    {
        List<Category> GetAll();
        List<Category> GetRoot();
        List<Category> GetNode(int ParentID);
        void SaveCategory(Category category);
        Category DeleteCategory(int CategoryID);
        Category GetById(int CategoryId);
        List<Category> Find(string query);

    }
}
