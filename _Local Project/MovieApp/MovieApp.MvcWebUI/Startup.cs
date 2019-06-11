using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace MovieApp.MvcWebUI
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            //MVCyi aktif etmen gerekiyor
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvcWithDefaultRoute();

            // app.UseDeveloperExceptionPage();


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            //orn 404 hatasıni donderebılmek ıcın 
            app.UseStatusCodePages();

        }
    }
}
