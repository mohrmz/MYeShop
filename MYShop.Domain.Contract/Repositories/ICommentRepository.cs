using MYShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MYShop.Domain.Contract.Repositories
{
    public interface ICommentRepository
    {
        void AddComment(Comment comment);
    }
}
