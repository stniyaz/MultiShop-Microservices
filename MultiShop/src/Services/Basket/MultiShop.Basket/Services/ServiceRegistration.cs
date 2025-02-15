using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using MultiShop.Basket.Settings;

namespace MultiShop.Basket.Services;

public static class ServiceRegistration
{
    public static void AddServices(this IServiceCollection services, WebApplicationBuilder builder)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
        {
            opt.Authority = builder.Configuration["IdentityServer"];
            opt.Audience = "ResourceBasket";
            opt.RequireHttpsMetadata = false;
            opt.MapInboundClaims = false;
        });

        services.AddScoped<IBasketService, BasketService>();
        services.AddScoped<ILoginService, LoginService>();
        services.Configure<RedisSettings>(builder.Configuration.GetSection("RedisSettings"));
        builder.Services.AddSingleton<RedisService>(sp =>
        {
            var redisSettings = sp.GetRequiredService<IOptions<RedisSettings>>().Value;
            var redis = new RedisService(redisSettings.Host, redisSettings.Port);
            redis.Connect();
            return redis;
        });

        services.AddHttpContextAccessor();
    }
}