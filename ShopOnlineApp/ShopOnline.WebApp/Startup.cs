using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShopOnline.BAL;
using ShopOnline.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.WebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions<ProductCatalogServiceOption>()
                .Bind(Configuration.GetSection(MicroserviceConfigOptions.ProductCatalogService));

            services.AddOptions<DiscountServiceOption>()
                .Bind(Configuration.GetSection(MicroserviceConfigOptions.DiscountService));

            services.AddOptions<MessagingOptions>().
                Bind(Configuration.GetSection(MessagingOptions.Messaging));

            services.AddScoped(typeof(IProductCatalogManager), typeof(ProductCatalogManager));
            services.AddSingleton(typeof(ICartManager), typeof(CartManager));
            services.AddSingleton(typeof(IOrderManager), typeof(OrderManager));
            services.AddScoped(typeof(IPaymentManager), typeof(PaymentManager));

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=ProductCatalog}/{action=Index}/{id?}");
            });
        }
    }
}
