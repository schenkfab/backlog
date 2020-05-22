using AutoMapper;
using backlog.Contexts;
using backlog.Middleware;
using backlog.Repositories;
using backlog.ServiceCollection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

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
            origins[1] = ;
            services.AddCors(options =>
            {
                options.AddPolicy("MyCorsPolicy",
                builder =>
                {
                    builder.WithOrigins("https://backlogweb.azurewebsites.net").AllowAnyHeader().AllowAnyMethod();
                });
            });
            services.AddRepositoryService();

            services.AddScoped<IUserObject, UserObject>();

            services.AddDbContext<DatabaseContext>(opt =>
            {
                //TODO: Include anstatt Lazy Loading
                opt.UseLazyLoadingProxies();
                opt.UseSqlServer(Configuration["connectionString"]);
            });

            services.AddControllers();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("MyCorsPolicy");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseMiddleware<UserMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
