using Bigon.WebUI.AppCode.Services;
using Microsoft.EntityFrameworkCore;
using MultiShopProject.Context;

namespace MultiShopProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<DataContext>(
                cfg =>
                {
                    cfg.UseSqlServer(builder.Configuration.GetConnectionString("cString"),
                        opt =>
                        {
                            opt.MigrationsHistoryTable("Migrations");
                        });
                });
            builder.Services.AddRouting(cfg => cfg.LowercaseUrls = true);

            builder.Services.Configure<EmailOptions>(
   builder.Configuration.GetSection("emailAccount"));
            builder.Services.AddSingleton<IEmailService, EmailService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

          

            app.UseEndpoints(endpoints =>
            {
                // Area routelar
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");

                // Default route
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=home}/{action=index}/{id?}");
            });
            app.Run();
        }
    }
}