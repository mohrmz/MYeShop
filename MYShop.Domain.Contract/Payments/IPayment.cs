using MYShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MYShop.Domain.Contract.Payments
{
    public interface IPayment
    {
        PaymentResult pay(string amount);
        VerifyResponse Verify(string transID);
    }
}
