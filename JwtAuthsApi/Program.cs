
using JwtAuthsApi.Models;
using JwtAuthsApi.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace JwtAuthsApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("Env"));
            })
           .AddIdentity<UserRegister, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            builder.Services.AddLogging();
             builder.Services.AddScoped<IUserAuthentication, UserAuthenticationService>(option =>
            {
                option.GetService<SignInManager<IdentityUser>>();
                option.GetService<UserManager<UserRegister>>();
                option.GetService<ApplicationDbContext>();
                return new UserAuthenticationService(option.GetService<SignInManager<Login>>(), option.GetService<UserManager<UserRegister>>(), option.GetService<ApplicationDbContext>());
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