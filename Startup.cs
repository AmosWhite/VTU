using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Amos.VTUCORE3._1.Models.BLL;
using Amos.VTUCORE3._1.Models.BLL.Interface;
using Amos.VTUCORE3._1.Models.DTO;
using Amos.VTUCORE3._1.Models.Repo.Infrastructure;
using Amos.VTUCORE3._1.Models.Repo.Infrastructure.Contract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Amos.VTUCORE3._1
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
            services.AddDbContextPool<AmosVTU_Context>(
                options => options.UseSqlServer(Configuration.GetConnectionString("AmosVTU_Context")));

            services.AddSingleton<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IProductBussiness, ProductBussiness>();
            services.AddSingleton<IAirtimeBussiness, AirtimeBussiness>();
            services.AddSingleton<IUserBussiness, UserBussiness>();

            services.AddControllersWithViews();

            services.AddIdentity<UserProfile, IdentityRole>()
                .AddEntityFrameworkStores<AmosVTU_Context>();
#if DEBUG
            services.AddRazorPages().AddRazorRuntimeCompilation();

            // Uncomment this code to disable client side validations.
            //    .AddViewOptions(option =>
            //{
            //    option.HtmlHelperOptions.ClientValidationEnabled = false;
            //});
#endif
            services.AddControllersWithViews(options =>
            {
                var policy = new AuthorizationPolicyBuilder()
                                .RequireAuthenticatedUser()
                                .Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("DeleteRolePolicy",
                    policy => policy.RequireClaim("Delete Role"));
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("EditRolePolicy",
                    policy => policy.RequireClaim("Edit Role"));
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
                app.UseExceptionHandler("/Error");
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
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
