using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MYShop.DAL.EF;
using MYShop.DAL.EF.Repositories;
using MYShop.Domain.Contract.Payments;
using MYShop.Domain.Contract.Repositories;
using MYShop.Domain.Entities;
using MYShop.Web.UI.Models;
using MYShop.Web.UI.Models.Identity;
using MYShop.Web.UI.Payment;

namespace MYShop.Web.UI
{
    public class Startup
    {
        IConfigurationRoot Configuration;
        public Startup(IHostingEnvironment env)
        {
            Configuration = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json").Build();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppIdentityDbContext>(options =>
              options.UseSqlServer(Configuration.GetConnectionString("IdentityCnn")));
            services.AddIdentity<IdentityUser, IdentityRole>()
            .AddEntityFrameworkStores<AppIdentityDbContext>();

            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(
               Configuration.GetConnectionString("MYShop")));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<Cart>(sp => SessionCart.GetCart(sp));
            services.AddTransient<CompareProduct>(s => SessionProductCompare.GetCompareProduct(s));
            services.AddTransient<IPayment, PayIrPayment>();
            services.AddScoped<IProductRepository, EfProductRepository>();
            services.AddScoped<IOrderRepository, EfOrderRepository>();
            services.AddScoped<ICategoryRepository, EFCategoryRepository>();
            services.AddScoped<IBrandRepository, EFBrandRepository>();
            services.AddScoped<IPropertyRepository, EFPropertyRepository>();
            services.AddScoped<IProductPropertiesRepository, EFProductPropertiesRepository>();
            services.AddScoped<IProductImages, EFProductImagesRepository>();
            services.AddScoped<INewsUserRespository, EFNewsUserRepository>();
            services.AddScoped<ICommentRepository, EFCommentRepository>();
            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            app.UseAuthentication();
            app.UseMvc(routes => {
                routes.MapRoute(
                name: "areas",
                template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
              );

                routes.MapRoute(
                name: "default",
                template: "{controller=home}/{action=index}/{id?}");
            });
        }
    }
}