﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace FanSoft.CadCli.Api
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddCors();
            services.AddScoped(typeof(Core.Data.EF.CadCliDataContext));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, Core.Data.EF.CadCliDataContext ctx)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                Core.Data.EF.DbInitialize.Initialize(ctx);
            }

            app.UseCors(options =>
            {
                options.AllowAnyHeader();
                options.AllowAnyMethod();
                options.AllowAnyOrigin();
            });

            app.UseMvc();

            app.Run(async (context) =>
            {
                context.Response.StatusCode = (int)System.Net.HttpStatusCode.NotFound;
                context.Response.Headers.Add("content-type", "text/html; charset=utf-8");
                await context.Response.WriteAsync("Recurso não encontrado");
            });
        }
    }
}
