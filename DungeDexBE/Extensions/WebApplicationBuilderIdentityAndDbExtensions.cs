using System.Text;
using DungeDexBE.Models;
using DungeDexBE.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace DungeDexBE.Extensions
{
	public static class WebApplicationBuilderIdentityAndDbExtensions
	{
		public static WebApplicationBuilder ConfigureIdentityAndDatabase(this WebApplicationBuilder builder)
		{
			builder.Configuration.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("Secrets.json");
			builder.Services.AddDbContext<ApplicationDbContext>(options =>
			{
				options.UseSqlServer(builder.Configuration.GetConnectionString("MyCnString"));
			});
			builder.Services.AddIdentity<User, IdentityRole>()
				.AddEntityFrameworkStores<ApplicationDbContext>()
				.AddDefaultTokenProviders();
			var key = Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]);
			builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
			.AddJwtBearer(options =>
			{
				options.RequireHttpsMetadata = false;
				options.SaveToken = true;
				options.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(key),
					ValidateIssuer = false,
					ValidateAudience = false
				};
			});
			return builder;
		}
	}
}
