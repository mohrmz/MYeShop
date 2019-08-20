using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MYShop.Domain.Entities
{
    public class Order
    {
        
            [BindNever]
            public int OrderID { get; set; }
            [BindNever]
            public ICollection<CartLine> Lines { get; set; }
            [Required(ErrorMessage = "لطفا نام وارد کنید")]
            [MaxLength(100)]
            public string Name { get; set; }
            [Required(ErrorMessage = "لطفا آدرس را وارد کنید")]
            [MaxLength(200)]
            public string Address { get; set; }
            [Required(ErrorMessage = "لطفا نام شهر را وارد کنید")]
            [MaxLength(100)]
            public string City { get; set; }
            [Required(ErrorMessage = "لطفا نام استان را وارد کنید")]
            [MaxLength(100)]
            public string State { get; set; }
            [Required(ErrorMessage = "لطفا تلفن همراه را وارد کنید")]
            [MaxLength(20)]
            public string Phone { get; set; }
            [Required(ErrorMessage = "لطفا کد پستی خود را وارد کنید")]
            [MaxLength(100)]
            public string PostalCode { get; set; }
            [MaxLength(100)]
            public string PaymentId { get; set; }
            public DateTime? PaymentDate { get; set; }
            public bool Shipped { get; set; }
        }
}
