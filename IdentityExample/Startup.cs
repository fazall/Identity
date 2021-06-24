using IdentityExample.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace IdentityExample
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<AppDbContext>(config =>
            {
                config.UseInMemoryDatabase("Memory");
            });

            services.AddIdentity<IdentityUser, IdentityRole>()
                    .AddEntityFrameworkStores<AppDbContext>()
                    .AddDefaultTokenProviders();
            //services.AddAuthentication("CookieAuth")
            //         .AddCookie("CookieAuth", config =>
            //         {
            //             config.Cookie.Name = "WebNetCookie";
            //             config.LoginPath = "/Home/Authenticate";
            //         });
            services.AddControllersWithViews();

        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }



            app.UseRouting();

           // app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
