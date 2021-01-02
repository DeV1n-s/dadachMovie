using System;
using System.Text;
using AutoMapper;
using dadachMovie.Contracts;
using dadachMovie.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SpaServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
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

            services.AddDbContextPool<AppDbContext>( opt =>
            {
                opt.UseMySql(Configuration.GetConnectionString("MariaDbConnection"),
                            new MariaDbServerVersion(new System.Version(10, 5, 0)));
            });

            services.AddAutoMapper(typeof(Startup));

            services.AddTransient<IFileStorageService, InAppStorageService>();
            services.AddTransient<IHostedService, MovieInTheaterService>();
            services.AddScoped<IGenresService, GenresService>();
            services.AddScoped<ICountriesService, CountriesService>();
            services.AddScoped<IMoviesService, MoviesService>();
            services.AddScoped<IPeopleService, PeopleService>();
            services.AddScoped<IAccountsService, AccountsService>();

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt =>
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(Configuration["jwt:key"])),
                        ClockSkew = TimeSpan.Zero
                    }
                );

            services.AddHttpContextAccessor();
            services.AddSwaggerGen( c => 
                {
                    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                    {
                        Type = SecuritySchemeType.Http,
                        BearerFormat = "JWT",
                        In = ParameterLocation.Header,
                        Scheme = "bearer",
                        Description = "Please insert JWT token into field"
                    });

                    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] { }
                        }
                    });
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
       public void Configure (IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
                //app.UseSwagger();
            } else {
                app.UseExceptionHandler ("/Error");
                app.UseHsts ();
            }

            // app.UseHttpsRedirection ();
            
            app.UseSpaStaticFiles ();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseRouting ();

            app.UseAuthentication();
            
            app.UseAuthorization();

            app.UseCors(builder => builder
                .AllowAnyMethod()
                .AllowAnyHeader()
                .WithOrigins("http://localhost:8080")
                .WithOrigins("http://localhost:5000"));

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
