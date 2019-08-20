using Microsoft.EntityFrameworkCore;
using MYShop.Domain.Contract.Repositories;
using MYShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MYShop.DAL.EF.Repositories
{
    public class EfOrderRepository : IOrderRepository
    {
        private ApplicationContext context;
        public EfOrderRepository(ApplicationContext ctx)
        {
            context = ctx;
        }

        public Order GetById(int orderId)
        {
            return context.Order.Include(c => c.Lines).ThenInclude(l => l.Product).FirstOrDefault(c => c.OrderID == orderId);
        }

        public List<Order> GetList(bool? shipped)
        {
            return context.Order.Where(c => !shipped.HasValue || c.Shipped == shipped.Value).Include(c => c.Lines).ThenInclude(l => l.Product).ToListAsync().Result;
        }

        public void SaveOrder(Order order)
        {
            context.AttachRange(order.Lines.Select(l => l.Product));
            if (order.OrderID == 0)
            {
                context.Order.Add(order);
            }
            context.SaveChanges();
        }

        public void SetPaymentDone(int transId)
        {
            var order = context.Order.FirstOrDefault(c => c.PaymentId == transId.ToString());
            if (order != null)
            {
                order.PaymentDate = DateTime.Now;
                context.SaveChanges();
            }
        }

        public void SetTransactionId(int orderId, string transId)
        {
            var order = context.Order.Find(orderId);
            if (order != null)
            {
                order.PaymentId = transId;
                context.SaveChanges();
            }
        }
    }
}
