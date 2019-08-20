using MYShop.Domain.Contract.Repositories;
using MYShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MYShop.DAL.EF.Repositories
{
    public class EFNewsUserRepository : INewsUserRespository
    {
        private readonly ApplicationContext _context;
        public EFNewsUserRepository(ApplicationContext context)
        {
            _context = context;
        }


        public string SaveCategory(string Emails)
        {
                string result = "";
                NewsUsers dbEntry = _context.NewsUsers.
               Where(c => c.Email.StartsWith(Emails)).FirstOrDefault();

            if (dbEntry != null)
                {
                result = "ایمیل شما قبلا در خبرنامه ثبت شده است به زودی منتظر اخبار فروش کالا ها با تخفیفات ویژه باشید";
                }
            else
            {
                result = " ایمیل شما با موفقیت در خبرنامه ثبت شد به زودی منتظر اخبار فروش کالا ها با تخفیفات ویژه باشید";
                NewsUsers dbEntry1 = new NewsUsers();
                dbEntry1.Email = Emails;
                _context.Add(dbEntry1);
                _context.SaveChanges();
            }

            return result;
        }
    }
}
