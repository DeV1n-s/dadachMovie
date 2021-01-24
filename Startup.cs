using System;
using System.IO;
using System.Text;
using System.Text.Json.Serialization;
using AutoMapper;
using dadachMovie.Contracts;
using dadachMovie.Entities;
using dadachMovie.Helpers;
using dadachMovie.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.SpaServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NLog;
using VueCliMiddleware;

namespace dadachMovie
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(),"/nlog.config"));
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers()
                .AddNewtonsoftJson()
                .AddJsonOptions(options => 
                            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));;
                
            services.AddCors(c => 
                {
                    c.AddPolicy(name: MyAllowSpecificOrigins, opt =>  
                                            opt.WithOrigins("http://localhost:5000",
                                                            "http://localhost:8080")
                                                .AllowAnyHeader()
                                                .AllowAnyMethod()
                                                .AllowCredentials());
                });

            // In production, the Vue files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "wwwroot";
            });

            services.AddDbContext<AppDbContext>( opt =>
            {
                opt.UseMySql(Configuration.GetConnectionString("MariaDbConnection"),
                            new MariaDbServerVersion(new System.Version(10, 5, 0)));
            });

            services.AddAutoMapper(typeof(Startup));
            
            services.AddTransient<IFileStorageService, InAppStorageService>();
            services.AddTransient<IHostedService, MovieInTheaterService>();
            //services.AddTransient<IHostedService, CastAndDirectorUpdateService>();
            services.AddScoped<IGenresService, GenresService>();
            services.AddScoped<ICountriesService, CountriesService>();
            services.AddScoped<IMoviesService, MoviesService>();
            services.AddScoped<IPeopleService, PeopleService>();
            services.AddScoped<IAccountsService, AccountsService>();
            services.AddScoped<ILoggerService, LoggerService>();
            services.AddScoped<IRatingService, RatingService>();
            services.AddScoped<IUserFavoriteMoviesService, UserFavoriteMoviesService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IRequestsService, RequestsService>();

            services.AddIdentity<User, Role>(opt =>
                {
                    opt.User.RequireUniqueEmail = true;
                })
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(opt => 
                {
                    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                })
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
            services.AddResponseCaching();
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
       public void Configure (IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            } else {
                app.UseExceptionHandler ("/Error");
                app.UseHsts();
            }

            // app.UseHttpsRedirection ();
            if ((!env.IsEnvironment("Backend")))
            {
                app.UseSpaStaticFiles();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseResponseCaching();

            app.UseRouting();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthentication();
            
            app.UseAuthorization();

            app.UseEndpoints (endpoints => {
                endpoints.MapControllers();
                if ((!env.IsEnvironment("Backend")))
                {
                    endpoints.MapToVueCliProxy (
                    "{*path}",
                    new SpaOptions { SourcePath = "ClientApp" },
                    npmScript: (env.IsEnvironment("Backend") ? null : "serve"),
                    regex: "Compiled successfully",
                    forceKill : true
                );}
            });

            ServiceExtensions.CreateDefaultRolesAndUser(serviceProvider).Wait();
        }
    }
}
