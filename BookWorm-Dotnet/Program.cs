
using BookWorm_Dotnet.Repository;
using BookWorm_Dotnet.ServicesImpl;
using BookWorm_Dotnet.Services;
using Microsoft.EntityFrameworkCore;
using BookWorm_Dotnet.Service;
using System.Text.Json.Serialization;
using Microsoft.OpenApi.Models;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace BookWorm_Dotnet
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var jwtSettings = builder.Configuration.GetSection("Jwt");

            var key = Encoding.UTF8.GetBytes(jwtSettings["SecretKey"] ?? throw new InvalidOperationException("JWT SecretKey is missing"));

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true, // Ensure expired tokens are rejected
                        ClockSkew = TimeSpan.Zero, // Optional: Prevents automatic token expiration buffer (default is 5 min)
                        ValidAudience = jwtSettings["Audience"],
                        ValidIssuer = jwtSettings["Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                    };

                    // Optional: Disable HTTPS metadata check in development
                    if (builder.Environment.IsDevelopment())
                    {
                        options.RequireHttpsMetadata = false;
                    }
                });

            builder.Services.AddAuthorization();

            // Swagger JWT support
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Test01", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter 'Bearer <your_token>'"
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
            new string[] {}
        }
    });
            });

            var configuration = builder.Configuration;

            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IProductService,ProductServiceImpl>();
            builder.Services.AddScoped<ICustomerService, CustomerServiceImpl>();
            builder.Services.AddScoped<IUserActivityService, UserActivityServiceImpl>();
            builder.Services.AddScoped<ILanguageMasterService, LanguageServiceImpl>();
            builder.Services.AddScoped<IGenreService, GenreServiceImpl>();
            builder.Services.AddScoped<IProductTypeService, ProductTypeServiceImpl>();
            builder.Services.AddScoped<ICartService, CartServiceImpl>();
            builder.Services.AddScoped<IMyShelfService, MyShelfServiceImpl>();
            builder.Services.AddScoped<ICartDetailsService, CartDetailsServiceImpl>();
            builder.Services.AddScoped<IShelfDetailsService, ShelfDetailsServiceImpl>();
            builder.Services.AddScoped<IInvoiceDetailsService, InvoiceDetailsServiceImpl>();
            builder.Services.AddScoped<IInvoiceService, InvoiceServiceImpl>();
            builder.Services.AddScoped<IRoyaltyCalculationService, RoyaltyCalculationServiceImpl>();
            builder.Services.AddScoped<IJwtService, JwtService>();




            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<BookWormDbContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            //builder.Services.AddHttpClient<CheckOutService>();
            //builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));


            // Register Database Logger
            builder.Services.AddSingleton<ILoggerProvider, DatabaseLoggerProvider>();
            builder.Services.AddSingleton<IOtpService, OtpService>();
            builder.Services.AddSingleton<IEmailService, EmailService>();
            // Add Logging Configuration
            builder.Logging.ClearProviders();
            builder.Logging.AddConsole();
            builder.Logging.AddDebug();
            //builder.Services.AddSingleton<ILoggerProvider>(sp => new DatabaseLoggerProvider(sp.GetRequiredService<IServiceScopeFactory>()));
            builder.Services.AddHttpClient();

            // Enable CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    policy =>
                    {
                        policy.AllowAnyOrigin()
                              .AllowAnyMethod()
                              .AllowAnyHeader();
                    });
            });

            builder.Services.AddControllers()
      .AddJsonOptions(options =>
      {
          options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
          options.JsonSerializerOptions.MaxDepth = 10;
      });



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("AllowAll"); // Apply CORS policy

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
