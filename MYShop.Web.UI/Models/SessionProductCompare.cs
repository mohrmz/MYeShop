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
    public class SessionProductCompare : CompareProduct
    {
        public static CompareProduct GetCompareProduct(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
            .HttpContext.Session;
            SessionProductCompare ProductCompare = session?.GetJson<SessionProductCompare>("Compare")
            ?? new SessionProductCompare();
            ProductCompare.Session = session;
            return ProductCompare;
        }
        [JsonIgnore]
        public ISession Session { get; set; }
        public override void AddItem(Product product)
        {
            base.AddItem(product);
            Session.SetJson("Compare", this);
        }
     
        public override void RemoveLine(Product product)
        {
            base.RemoveLine(product);
            Session.SetJson("Compare", this);
        }
        public override void Clear()
        {
            base.Clear();
            Session.Remove("Compare");
        }
    }
}
