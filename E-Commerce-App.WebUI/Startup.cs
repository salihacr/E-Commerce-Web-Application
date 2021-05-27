using AutoMapper;
using E_Commerce_App.Business.Services;
using E_Commerce_App.Core.Repositories;
using E_Commerce_App.Core.Services;
using E_Commerce_App.Core.Shared.Helper;
using E_Commerce_App.Core.Shared.Mapping;
using E_Commerce_App.Core.UnitOfWorks;
using E_Commerce_App.Data;
using E_Commerce_App.Data.Repositories;
using E_Commerce_App.Data.UnitOfWorks;
using E_Commerce_App.WebUI.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;

namespace E_Commerce_App.WebUI
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
            services.AddControllersWithViews().AddRazorRuntimeCompilation();


            // DbContext
            services.AddDbContext<AppDbContext>();

            // identity
            services.AddDbContext<UserContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
            );
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<UserContext>()
                .AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(options =>
            {
                // lockout
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.AllowedForNewUsers = true;

                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = true;
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/logout";
                options.AccessDeniedPath = "/account/accessdenied";
                options.SlidingExpiration = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                options.Cookie = new CookieBuilder
                {
                    HttpOnly = true,
                    Name = "E_Commerce_App.Cookie",
                    SameSite = SameSiteMode.Strict
                };

            });

            // API Services

            // Automapper
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MapProfile>();
            });
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            // unitofwork
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Dependency Injection
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(Core.Services.IService<>), typeof(Business.Services.Service<>));


            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICartService, CartService>();


            // email sender dependency injection
            services.AddScoped<IEmailSender, SmtpEmailSender>(i =>
            new SmtpEmailSender(
                Configuration["EmailSender:Host"],
                Configuration.GetValue<int>("EmailSender:Port"),
                Configuration.GetValue<bool>("EmailSender:EnableSSL"),
                Configuration["EmailSender:UserName"],
                Configuration["EmailSender:Password"]
                )
            );

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
            RoleManager<IdentityRole> roleManager, UserManager<User> userManager
            ,ICartService cartService)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles(); // for wwwroot folder
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "node_modules")),
                RequestPath = "/node_modules"
            });

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                // Admin Pages
                endpoints.MapControllerRoute(
                   name: "adminproductadd",
                   pattern: "Admin/Product/Add",
                   defaults: new { controller = "AdminProduct", Action = "AddOrEdit" }
                   );
                endpoints.MapControllerRoute(
                   name: "adminproductadd",
                   pattern: "Admin/Product/Edit/{id}",
                   defaults: new { controller = "AdminProduct", Action = "AddOrEdit" }
                   );
                endpoints.MapControllerRoute(
                   name: "adminproductdelete",
                   pattern: "Admin/Product/DeleteProduct/{id}",
                   defaults: new { controller = "AdminProduct", Action = "DeleteProduct" }
                   );
                endpoints.MapControllerRoute(
                   name: "adminproductadd",
                   pattern: "Admin/Product",
                   defaults: new { controller = "AdminProduct", Action = "Index" }
                   );
                endpoints.MapControllerRoute(
                    name: "admincategory",
                    pattern: "Admin/Category",
                    defaults: new { controller = "AdminCategory", Action = "Index" }
                    );

                endpoints.MapControllerRoute(
                   name: "admincategory",
                   pattern: "Admin/Campaign",
                   defaults: new { controller = "AdminCampaign", Action = "Index" }
                   );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            IdentitySeed.Seed(Configuration, userManager, roleManager, cartService).Wait();
        }
    }
}
