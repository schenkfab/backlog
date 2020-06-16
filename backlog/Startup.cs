using AutoMapper;
using backlog.Authentication;
using backlog.Contexts;
using backlog.Middleware;
using backlog.Repositories;
using backlog.ServiceCollection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Security.Claims;

namespace backlog
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
            string[] origins = new string[2];
            origins[0] = "http://localhost:8080";
            origins[1] = "https://backlogweb.azurewebsites.net";
            //services.AddCors(options =>
            //{
            //    options.AddPolicy("MyCorsPolicy",
            //    builder =>
            //    {
            //        builder.WithOrigins(origins).AllowAnyHeader().AllowAnyMethod();
            //    });
            //});
            services.AddRepositoryService();

            services.AddControllers();

            services.AddScoped<IUserObject, UserObject>();

            services.AddDbContext<DatabaseContext>(opt =>
            {
                //TODO: Include anstatt Lazy Loading
                opt.UseLazyLoadingProxies();
                opt.UseSqlServer(Configuration["connectionString"]);
            });

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.Authority = Configuration["Auth0:Domain"];
                options.Audience = Configuration["Auth0:ApiIdentifier"];
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    NameClaimType = ClaimTypes.NameIdentifier
                };
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("create:objectives", policy => policy.Requirements.Add(new HasPermissionRequirement("create:objectives", Configuration["Auth0:Domain"])));
            });

            services.AddSingleton<IAuthorizationHandler, HasPermissionHandler>();


            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseCors("MyCorsPolicy");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseMiddleware<UserMiddleware>();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
