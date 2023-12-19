using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MyWebAPI.Data;
using MyWebAPI.Models;
using MyWebAPI.Services;
using System.Text;

namespace MyWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("MyDB");
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<MyDbContext>(option =>
            {
                option.UseSqlServer(connectionString);
            });
            //builder.Services.AddScoped<ILoaiRepository, LoaiRepository>();
            builder.Services.AddScoped<ILoaiRepository, LoaiRepositoryInMemory>();
            builder.Services.AddScoped<IHangHoaRepository, HangHoaRepository>();
            builder.Services.Configure<AppSetting>(builder.Configuration.GetSection("AppSettings"));

            var secretKey = builder.Configuration["AppSettings:SecretKey"];
            var secretKeyBytes = Encoding.UTF8.GetBytes(secretKey);
            builder.Services.AddAuthentication
                (JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    //tự cấp token
                    ValidateIssuer = false,
                    ValidateAudience = false,

                    //ký vào token
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secretKeyBytes),

                    ClockSkew = TimeSpan.Zero
                };
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}