﻿/*
 * Demo application with WordPress.
 */

using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;

namespace peachserver
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseUrls("http://*:5004/")
                .Build();

            host.Run();
        }
    }

    class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddResponseCompression();

            services.AddWordPress(options =>
            {
                //
                options.SiteUrl = "http://localhost:5004/wordpress"; // Where the wordpress resides
                options.HomeUrl = "http://localhost:5004"; // What url has the client site
            });
        }

        public void Configure(IApplicationBuilder app, IHostEnvironment env, IConfiguration configuration)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // add wordpress into the pipeline
            // using default configuration from appsettings.json (IConfiguration), section WordPress
            // using empty set of .NET plugins
            app.UseWordPress();

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {

                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
