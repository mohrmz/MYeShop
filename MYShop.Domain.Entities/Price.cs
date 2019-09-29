using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MYShop.Domain.Entities
{
    public class Price
    {
        public int PriceID { get; set; }
        public int ProductColorID { get; set; }

        public int CategoryPriceID { get; set; }
        [NotMapped]
        public int CategoryID { get; set; }
        public int ProductID { get; set; }
        public int Value { get; set; }

        public int NewValue { get; set; }
        public int Discount { get; set; }

        public bool IsDeleted { get; set; }

        public string DateF { get; set; }

        public string DateT { get; set; }

        public Product Product { get; set; }

        
    }
}
