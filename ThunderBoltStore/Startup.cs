using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ThunderBoltDBLib.Models;
using ThunderBoltStore.Interfaces;
using ThunderBoltStore.Models;

namespace ThunderBoltStore
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
            services.AddDbContextPool<ThunderBoltContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("ThunderBoltDBConnection")));
            services.AddIdentity<IdentityUser, IdentityRole>(opt =>
            {
                opt.SignIn.RequireConfirmedEmail = false;
            }).AddEntityFrameworkStores<ThunderBoltContext>()
            .AddDefaultTokenProviders();
            services.AddControllersWithViews();
            services.AddScoped<IProductsRepository, SQLProductsRepository>();
            services.AddScoped<ISuppliersRepository, SQLSuppliersRepository>();
            services.AddScoped<IOrdersRepository, SQLOrdersRepository>();
            services.AddScoped<ICategoryRepository, SQLCategoryRepository>();
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddMvc();

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
                options.LoginPath = "/home/index";
                options.AccessDeniedPath = "/home/index";
                options.SlidingExpiration = true;
            });
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
