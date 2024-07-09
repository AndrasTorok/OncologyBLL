using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;

namespace OncologyReceiptsCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
                       
            builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new ReceiptModule()));

            // Add services to the container.
            builder.Services.AddCors();
            builder.Services.AddControllersWithViews();
            builder.Services.AddControllers().AddNewtonsoftJson(opt =>
            {
                opt.SerializerSettings.ContractResolver = new DefaultContractResolver();
                opt.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc;
                opt.SerializerSettings.DateFormatString = "yyyy-MM-ddTHH:mm:ssZ";
                opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });
            builder.Services.AddDbContext<OncologyCore.Model.OncologyReceiptsContext>(options =>
            {                
                options.UseSqlServer(builder.Configuration.GetConnectionString("OncologyReceiptsConnectionString"));
            });

            var app = builder.Build();

            app.UseCors((options) =>
            {                
                options.AllowAnyMethod().AllowAnyHeader().SetIsOriginAllowed(origin => true).AllowCredentials();
            });

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapControllerRoute(
                    name: "api",
                    pattern: "api/{controller=Home}/{action?}/{id?}");

            app.Run();
        }

        protected static void AutofacSetup()
        {
            var builder = new ContainerBuilder();

            RegisterCustomModules(builder);

            var container = builder.Build();
        }

        protected static void RegisterCustomModules(ContainerBuilder builder)
        {
            builder.RegisterModule(new ReceiptModule());
        }
    }
}
