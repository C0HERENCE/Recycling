using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Recycling.Areas;
using Recycling.Data;
using Recycling.Models;
using Recycling.Services;

namespace Recycling
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
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                // options.UseSqlite(
                //     Configuration.GetConnectionString("DefaultConnection"));
                options.UseSqlServer(
                    Configuration.GetConnectionString("SqlServerConnection"));
                options.EnableSensitiveDataLogging();
                options.EnableDetailedErrors();
            });
            services.AddDefaultIdentity<User>(options =>
                {
                    //密码设置
                    options.SignIn.RequireConfirmedAccount = true;
                    options.Password.RequireDigit = false;//是否要求有数字
                    options.Password.RequiredLength = 3;//密码要求的最小长度
                    options.Password.RequireLowercase = false;//是否要求有小写的ASCII码
                    options.Password.RequireUppercase = false;//是否要求有大写的ASCII码
                    options.Password.RequireNonAlphanumeric = false;//是否要求有非字母数字的字符
                    options.User.RequireUniqueEmail = true;
                })
                .AddRoles<Role>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services
                .AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>
                >();
            services.AddDatabaseDeveloperPageExceptionFilter();
            
            
            
            
            services.AddScoped<UserService>();
            services.AddScoped<OrderService>();
            services.AddScoped<CategoryService>();
            services.AddScoped<AddressService>();
            services.AddScoped<NewsService>();
            services.AddScoped<RecyclingService>();
            services.AddScoped<ProductService>();

            services.AddScoped<IEmailSender, EmailSenderService>();
            //services.AddScoped<ProductRecordService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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
            });
        }
    }
}