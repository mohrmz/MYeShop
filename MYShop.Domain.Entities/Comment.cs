using System;
using System.Collections.Generic;
using System.Text;

namespace MYShop.Domain.Entities
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string CommnetBy { get; set; }

        public string Name { get; set; }

        public string Lastname { get; set; }

        public string Phone { get; set; }
        public string Text { get; set; }

        public DateTime Date { get; set; }
        public int Vote { get; set; }
        public int ProductId { get; set; }
        public bool IsDeleted { get; set; }
        public Product Product { get; set; }
    }
}
