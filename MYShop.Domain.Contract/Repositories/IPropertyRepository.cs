using MYShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MYShop.Domain.Contract.Repositories
{
    public interface IPropertyRepository
    {
        List<Property> GetAll();
        List<Property> GetRoot(int CategoryId,bool isshort);
        List<Property> GetNode(int ParentID);
        void SaveProperty(Property Property);
        void DeleteProperty(int PropertyID);
        Property GetById(int PropertyID);
    }
}
