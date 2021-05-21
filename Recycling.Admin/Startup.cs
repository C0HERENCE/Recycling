using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Recycling.Admin.Areas.Identity;
using Recycling.Data;
using Recycling.Models;
using Recycling.Services;
using Telerik.Blazor.Services;

namespace Recycling.Admin
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
            services.AddControllers();
            services.AddLocalization(options => options.ResourcesPath = "Resources");
            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new List<CultureInfo>()
                {
                    new CultureInfo("zh-CN"),
                };

                options.DefaultRequestCulture = new RequestCulture("zh-CN");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });
            
            // 数据库配置
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(
                    Configuration.GetConnectionString("SqlServerConnection"));
                options.EnableSensitiveDataLogging();
                options.EnableDetailedErrors();
            });
            // 认证信息Scheme和保存位置
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = IdentityConstants.ApplicationScheme;
                options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
            }).AddIdentityCookies();
            // Identity配置
            services.AddIdentityCore<User>(options =>
                {
                    options.User.RequireUniqueEmail = true;
                    options.Password.RequireDigit = true;
                    options.Password.RequiredLength = 6;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                })
                .AddRoles<Role>()
                .AddSignInManager()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services
                .AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>
                >();
            services.AddDatabaseDeveloperPageExceptionFilter();
            
            services.AddTelerikBlazor();
            services.AddBlazoredSessionStorage();
            
            
            services.AddScoped<UserService>();
            services.AddScoped<OrderService>();
            services.AddScoped<CategoryService>();
            services.AddScoped<AddressService>();
            services.AddScoped<NewsService>();
            services.AddScoped<RecyclingService>();
            
            // register a custom localizer
            services.AddSingleton(typeof(ITelerikStringLocalizer), typeof(CustomStringLocalizer));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRequestLocalization(app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>().Value);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
                endpoints.MapPost("/api/file", async context =>
                {
                    var formFileCollection = context.Request.Form.Files;
                    var fileName = DateTime.Now.Ticks+new Random().Next(1,10) + ".jpg";
                    foreach (var file in formFileCollection)
                    {
                        {
                            var filePath = Path.Combine(env.WebRootPath + "\\img", fileName);
                            if (file.Length <= 0) continue;
                            await using Stream fileStream = new FileStream(filePath, FileMode.Create);
                            await file.CopyToAsync(fileStream);
                        }
                        {
                            var directoryInfo = Directory.GetParent(env.WebRootPath).Parent;
                            var filePath = Path.Combine(directoryInfo+ "\\Recycling\\wwwroot\\img", fileName);
                            if (file.Length <= 0) continue;
                            await using Stream fileStream = new FileStream(filePath, FileMode.Create);
                            await file.CopyToAsync(fileStream);
                        }
                    }
                    await context.Response.WriteAsync(fileName);
                });
            });
        }
    }
    public class CustomStringLocalizer : ITelerikStringLocalizer
    {
        public string this[string name]
        {
            get
            {
                return GetStringFromResource(name);
            }
        }

        public string GetStringFromResource(string key)
        {
            return Resources.Messages.ResourceManager.GetString(key, Resources.Messages.Culture);
        }
    }
    
}