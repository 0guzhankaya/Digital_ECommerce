using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace Digital_Infrastructure_Layer
{
	public static class ServiceRegistrations
	{
		public static void AddInfrastructureLayerServices(this IServiceCollection services, IConfiguration configuration = null)
		{

			#region SwaggerJwtSettings

			var key = configuration.GetValue<string>("SecretKey:jwtKey");
			services.AddAuthentication(u =>
			{
				u.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				u.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(u =>
			{
				u.RequireHttpsMetadata = false;
				u.SaveToken = true;
				u.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
					ValidateIssuer = false,
					ValidateAudience = false,
					ClockSkew = TimeSpan.Zero,
				};
			});

			services.AddSwaggerGen(options =>
			{
				options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new Microsoft.OpenApi.Models.OpenApiSecurityScheme
				{
					Name = "Authorization",
					Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
					Scheme = JwtBearerDefaults.AuthenticationScheme,
					BearerFormat = "JWT",
					In = Microsoft.OpenApi.Models.ParameterLocation.Header,
					Description = "JWT Authorization header using the Bearer scheme."
				});
				options.AddSecurityRequirement(new OpenApiSecurityRequirement()
				{
				{
						new OpenApiSecurityScheme
						{
							Reference = new OpenApiReference
							{
								Type = ReferenceType.SecurityScheme,
								Id = JwtBearerDefaults.AuthenticationScheme
							},
							Scheme = "oauth2",
							Name = JwtBearerDefaults.AuthenticationScheme,
							In = ParameterLocation.Header,
						},
						new List<string>()
					}
				});
			});

			#endregion
		}
	}
}