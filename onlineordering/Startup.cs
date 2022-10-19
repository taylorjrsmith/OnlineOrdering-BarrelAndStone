using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BlazorApp1.Data;
using Microsoft.EntityFrameworkCore;
using TKGroup.Settings;
using TKGroup.InHouseOrder.Data;
using BlazorApp1.Services;
using TKGroup.InHouseOrder.Common.Stations;
using TKGroup.InHouseOrder.Data.UtilityServices;

namespace BlazorApp1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<WeatherForecastService>();
            services.AddTransient<Data.OrderService>();
            services.AddScoped<Data.OrderState>();
            services.AddMemoryCache();
            services.AddSingleton<CacheHelper>();
            services.AddScoped<ManagementService>();
            services.AddTKGroupSettings();
            services.AddScoped<ISettingDbContext, PizzaStoreContext>();
            services.AddScoped<ISettingService, CacheSettingService>();
            services.AddDbContext<InHouseOrderContext>(c => { c.UseSqlServer(Configuration.GetConnectionString("inhouseordercontext")); }, ServiceLifetime.Transient);
            services.AddTransient<CollectionService>();
            services.AddTransient<ProductService>();
            services.AddTransient<OrderAPIService>();
            services.AddTransient<PizzaStoreContext>();
            services.AddTransient<TKGroup.InHouseOrder.Data.SettingsService>();
            services.AddMvc(options => options.EnableEndpointRouting = false).SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0);
            services.AddTransient<SpecialEventCategoryService>();
            services.AddTransient<StationClearRequestService>();
            services.AddDbContext<PizzaStoreContext>(options =>
                options.UseSqlite("Data Source=pizza.db"), ServiceLifetime.Transient);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, PizzaStoreContext context)
        {
            if (context.Database.GetPendingMigrations().Count<string>() > 0)
                context.Database.Migrate();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseMvcWithDefaultRoute();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
