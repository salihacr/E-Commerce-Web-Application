using E_Commerce_App.Business.Services;
using E_Commerce_App.Core.Repositories;
using E_Commerce_App.Core.Services;
using E_Commerce_App.Core.UnitOfWorks;
using E_Commerce_App.Data;
using E_Commerce_App.Data.Repositories;
using E_Commerce_App.Data.UnitOfWorks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
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

            // API Services

            // Automapper
            services.AddAutoMapper(typeof(Startup));

            // unitofwork
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Dependency Injection
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(Core.Services.IService<>), typeof(Business.Services.Service<>));


            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
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

                // Home Pages

                endpoints.MapControllerRoute(
                    name: "productdetails",
                    pattern: "{url}",
                    defaults: new { controller = "Shop", Action = "Detail" }
                    );


                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Shop}/{action=Index}/{id?}");
            });
        }
    }
}
