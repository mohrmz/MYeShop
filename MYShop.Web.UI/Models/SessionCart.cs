using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using MYShop.Domain.Entities;
using MYShop.Web.UI.Infrastructures;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MYShop.Web.UI.Models
{
    public class SessionCart : Cart
    {
        public static Cart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
            .HttpContext.Session;
            SessionCart cart = session?.GetJson<SessionCart>("Cart")
            ?? new SessionCart();
            cart.Session = session;
            return cart;
        }
        [JsonIgnore]
        public ISession Session { get; set; }
        public override void AddItem(Product product, int priceid, int price, int quantity)
        {
            base.AddItem(product, priceid,  price, quantity);
            Session.SetJson("Cart", this);
        }
        public override void minfromItem(Product product, int quantity)
        {
            base.minfromItem(product, quantity);
            Session.SetJson("Cart", this);
        }
        public override void RemoveLine(Product product)
        {
            base.RemoveLine(product);
            Session.SetJson("Cart", this);
        }
        public override void Clear()
        {
            base.Clear();
            Session.Remove("Cart");
        }
    }
}
