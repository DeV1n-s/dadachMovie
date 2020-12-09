using AutoMapper;
using dadachMovie.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using VueCliMiddleware;

namespace dadachMovie
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

            services.AddControllers()
                .AddNewtonsoftJson();
            
            services.AddCors();

            // In production, the Vue files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "wwwroot";
            });

            services.AddDbContextPool<AppDbContext>( options =>
            {
                options.UseSqlite(Configuration.GetConnectionString("SqliteConnection"));
            });

            services.AddAutoMapper(typeof(Startup));

            services.AddTransient<IFileStorageService, InAppStorageService>();
            services.AddTransient<IHostedService, MovieInTheaterService>();
            services.AddHttpContextAccessor();
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
       public void Configure (IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
                app.UseSwagger();
            } else {
                app.UseExceptionHandler ("/Error");
                app.UseHsts ();
            }

            // app.UseHttpsRedirection ();
            
            app.UseSpaStaticFiles ();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseRouting ();

            app.UseCors(builder => builder.WithOrigins("http://localhost:8080").WithOrigins("http://localhost:5000").AllowAnyMethod().AllowAnyHeader());

            app.UseEndpoints (endpoints => {
                endpoints.MapControllers ();

                endpoints.MapToVueCliProxy (
                    "{*path}",
                    new SpaOptions { SourcePath = "ClientApp" },
                    // npmScript: (System.Diagnostics.Debugger.IsAttached) ? "serve" : null,
                    npmScript: "serve",
                    regex: "Compiled successfully",
                    forceKill : true
                );
            });
        }
    }
}
