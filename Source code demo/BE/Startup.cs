using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SneakerShop.IService;
using SneakerShop.Models;
using SneakerShop.Service;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SneakerShop.IService.VNPay;
using SneakerShop.Service.VNPay;

namespace SneakerShop
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

            services.AddControllers();
            services.AddScoped<IUserService, UserService>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SneakerShop", Version = "v1" });
            });

            //config db
            services.AddDbContext<SneakerShopDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Default"));
            });

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builer =>
                {
                    builer.SetIsOriginAllowed(host => true);
                    builer.AllowAnyHeader();
                    builer.AllowAnyMethod();
                    builer.AllowCredentials();
                });
            });

            //cau hinh authentication
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Remove("sub");

            string secret = "g2sL6RLQh6dVRSSnCRjvEqP971-V2DGpFoUleIfKrIc";
            string iss = "dcaea177e8d14f1fb863059dde75ca3b";
            string audience = "BMS";

            var singinKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret));

            var tokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = singinKey,
                ValidateIssuer = true,
                ValidIssuer = iss,
                ValidateAudience = true,
                ValidAudience = audience,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
                RequireExpirationTime = true,
            };

            services.AddAuthentication("AuthKey")
                    .AddJwtBearer("AuthKey", x =>
                    {
                        x.TokenValidationParameters = tokenValidationParameters;
                        x.SaveToken = true;
                        x.RequireHttpsMetadata = false;
                    });
            services.AddAuthentication("UserKey")
                    .AddJwtBearer("UserKey", y =>
                    {
                        y.TokenValidationParameters = tokenValidationParameters;
                        y.SaveToken = true;
                        y.RequireHttpsMetadata = false;
                    });
            services.AddScoped<IVNPayService, VNPayService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SneakerShop v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseCors("CorsPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
