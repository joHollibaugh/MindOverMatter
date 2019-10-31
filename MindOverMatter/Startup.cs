using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MindOverMatter.Models.DbContexts;
using MindOverMatter.Models.Identity;

namespace MindOverMatter
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            if (env != null)
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(env.ContentRootPath)
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                    .AddEnvironmentVariables();

                if (env.IsDevelopment())
                {

                }
                Configuration = builder.Build();
            }
        }

        public IConfigurationRoot Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddIdentity<ApplicationUser, Microsoft.AspNetCore.Identity.IdentityRole>().AddEntityFrameworkStores<ProfileContext>().AddDefaultTokenProviders();

            services.AddDbContext<Models.DbContexts.ProfileContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));
            services.AddDbContext<Models.DbContexts.ChemicalDbContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //We can opt to install this for crossbrowser testing
                //app.UseBrowserLink();
            }
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "index" }
                    );
            });
            app.UseAuthentication();
        }
    }
}
