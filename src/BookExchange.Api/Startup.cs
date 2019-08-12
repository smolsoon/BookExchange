using BookExchange.Infrastructure.Repositories;
using BookExchange.Infrastructure.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using BookExchange.Core.Repositories;
using BookExchange.Infrastructure.Services;
using BookExchange.Infrastructure.Mappers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace BookExchange.Api
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                    .AddJsonOptions(x => x.SerializerSettings.Formatting = Formatting.Indented);
            services.AddAuthorization();
            services.AddScoped<IUserRepository,UserRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IBookRelationalRepository, BookRelationalRepository>();
            services.AddScoped<IUserRelationalRepository, UserRelationalRepository>();
            services.AddScoped<IDivisionRelationalRepository, DivisionRelationalRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IBookRelationalService, BookRelationalService>();
            services.AddScoped<IUserRelationalService, UserRelationalService>();
            services.AddScoped<IDivisionRelationalService, DivisionRelationalService>();
            services.AddSingleton<IJwtHandler,JwtHandler>();
            services.AddSingleton(AutoMapperConfig.Initialize());
            services.Configure<Neo4JSettings>(Configuration.GetSection("neo4j"));

            var jwtSettings = Configuration.GetSection("jwt");
            services.Configure<JwtSettings>(jwtSettings);

            var _jwt = jwtSettings.Get<JwtSettings>();
            var key = Encoding.ASCII.GetBytes(_jwt.Key);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddSwaggerGen(c=> 
                { c.SwaggerDoc("v1", new Info 
                    { Title = "BookExchange", Version = "V1" });  
                });   
            services.AddSignalR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            
            app.UseCors (x =>
                x.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
            );
            
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseSwagger();  
            app.UseSwaggerUI(c=> {  
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "post API V1");  
                }); 
        }
    }
}
