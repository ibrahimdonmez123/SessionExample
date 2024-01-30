using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace SessionExample
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Oturum kullanımını etkinleştirdim
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30); // Oturum süresi
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            
            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app)
        {

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseSession();
        }
    }
}
