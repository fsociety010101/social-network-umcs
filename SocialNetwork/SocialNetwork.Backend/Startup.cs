using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Primitives;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Cors.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.App.Model;
using System.Text.Json;
using SocialNetwork.App.Utils;
using SocialNetwork.Data;

namespace SocialNetwork.App
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<DefaultContext>(options =>
            {
                var connectionString = Configuration.GetConnectionString("Database");
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), options => options.EnableRetryOnFailure());
            });
            services.Configure<JsonOptions>(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new DateOnlyConverter());
            });
            services.AddCors(options => options.AddPolicy("CorsPolicy", builder =>
            {
                builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
            }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ICorsService corsService, ICorsPolicyProvider corsPolicyProvider)
        {
            app.UseCors("CorsPolicy");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //app.UseHttpsRedirection();
            }

            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            //app.UseStaticFiles(new StaticFileOptions
            //{
            //    //OnPrepareResponse = (ctx) =>
            //    //{
            //    //    var policy = corsPolicyProvider.GetPolicyAsync(ctx.Context, "CorsPolicy")
            //    //        .ConfigureAwait(false)
            //    //        .GetAwaiter().GetResult();

            //    //    var corsResult = corsService.EvaluatePolicy(ctx.Context, policy);

            //    //    corsService.ApplyResult(corsResult, ctx.Context.Response);
            //    //}

            //    OnPrepareResponse = ctx =>
            //    {
            //        ctx.Context.Response.Headers.Append(new KeyValuePair<string, StringValues>("Access-Control-Allow-Origin", "*"));
            //        ctx.Context.Response.Headers.Append(new KeyValuePair<string, StringValues>("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept"));
            //    }
            //});

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
