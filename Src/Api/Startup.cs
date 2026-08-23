using Api.Service;
using DotNetEnv;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using System.Text;

namespace Api
{
    public class Startup
    {
        private WebApplicationBuilder Builder;
        public Startup(WebApplicationBuilder builder)
        {
            Builder = builder;
        }

        public void ConfigureConnectionString()
        {
            //Env.Load("./.env");
            Env.Load(Path.Combine(AppContext.BaseDirectory, ".env"));

            var connectionString = Environment.GetEnvironmentVariable("DefaultConnection")
                ?? throw new InvalidOperationException("DefaultConnection not configured");


            Builder.Services.AddDbContext<DBContext>(options =>
                options.UseNpgsql(connectionString));
        }

        public void ConfigureJWTToken()
        {
            //Env.Load("./.env");
            Env.Load(Path.Combine(AppContext.BaseDirectory, ".env"));

            var Secret = Environment.GetEnvironmentVariable("Secret");

            Builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Secret)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };

                    options.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = ctx =>
                        {
                            Console.WriteLine($"[JWT] FAILED: {ctx.Exception.GetType().Name}: {ctx.Exception.Message}");
                            return Task.CompletedTask;
                        },
                        OnMessageReceived = ctx =>
                        {
                            Console.WriteLine($"[JWT] Header: {ctx.Request.Headers.Authorization}");
                            return Task.CompletedTask;
                        }
                    };
                });
        }

        public void ConfigureSwaggerGen()
        {
            Builder.Services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("bearer", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Description = "Enter your token"
                });

                options.AddSecurityRequirement(document => new OpenApiSecurityRequirement
                {
                    [new OpenApiSecuritySchemeReference("bearer", document)] = []
                });

            });
        }

        public void ConfigureCors()
        {
            Builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.WithOrigins("http://localhost:5000", "http://localhost:5173")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });

            });
        }

        public void AddServices()
        {
            Builder.Services.AddScoped<IAccountService, AccountService>();
        }

        public void AddRepository()
        {
            Builder.Services.AddScoped<IAccountRepository, AccountRepository>();
        }
    }
}
