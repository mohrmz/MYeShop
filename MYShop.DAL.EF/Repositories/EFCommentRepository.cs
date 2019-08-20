using MYShop.Domain.Contract.Repositories;
using MYShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MYShop.DAL.EF.Repositories
{
    public class EFCommentRepository : ICommentRepository
    {
        private readonly ApplicationContext _context;
        public EFCommentRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void AddComment(Comment comment)
        {

            comment.Date = DateTime.Now;
            _context.Comments.Add(comment);
            _context.SaveChanges();
        }
    }
}
