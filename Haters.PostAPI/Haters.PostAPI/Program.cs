using Haters.PostAPI.Data;
using Haters.PostAPI.Services;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Security.Claims;
using FluentValidation;
using Haters.PostAPI.Common.Behaviors;
using Haters.PostAPI.Common.Mapping;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        builder.Services.AddControllers();
        builder.Services.AddAutoMapper(config =>
        {
            config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
            config.AddProfile(new AssemblyMappingProfile(typeof(IPostDbContext).Assembly));
        });
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSingleton<IPostHolder, PostHolder>();
        builder.Services.AddSingleton<ICurrentUserService, CurrentUserService>();
        builder.Services.AddPersistence(builder.Configuration);
        builder.Services.AddMediatR(config => config.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        builder.Services.AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });
        builder.Services.AddTransient(typeof(IPipelineBehavior<,>),
            typeof(ValidationBehavior<,>));
        builder.Services.AddHttpContextAccessor();

        builder.Services.AddCors(config =>
        {
            config.AddPolicy("DefaultPolicy",
                builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
        });
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, config =>
            {
                config.TokenValidationParameters = new TokenValidationParameters
                {
                    ClockSkew = TimeSpan.FromSeconds(5),
                    ValidateAudience = false
                };
                config.Authority = "https://localhost:10001";
                config.Audience = "https://localhost:10001";
            });
        builder.Services.AddAuthorization();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {

        }

        try
        {
            var context = app.Services.GetRequiredService<PostDbContext>();
            DbInitializer.Initialize(context);
        }
        catch
        {

        }

        app.UseRouting();
        app.UseHttpsRedirection();
        app.UseCors("DefaultPolicy");
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}