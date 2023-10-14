
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using WSfinanceperson.Application.Services;
using WSfinanceperson.Infrastructure;
using WSfinanceperson.Infrastructure.Services;

namespace Inventario.WebApi
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
            services.AddInfrastructure(Configuration);
            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WSfinanceperson.WebApi", Version = "v1" });
            });

            // auth token Bearer
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = "https://localhost:7268/",
                        ValidAudience = "https://localhost:7268/",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("WSFINANCE3T3N6PSJKWM")),
                        ClockSkew = TimeSpan.FromMinutes(5)
                    };
                });
            services.AddAuthorization();
            services.AddCors(c => c.AddPolicy("CorsPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
            }));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WSfinanceperson.WebApi v1"));
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
