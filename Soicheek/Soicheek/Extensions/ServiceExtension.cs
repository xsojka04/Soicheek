using Soicheek.BL.Services;

namespace Soicheek.Extensions;

public static class ServiceExtension
{
    public static void AddMyServices(this IServiceCollection services)
    {
        services.AddScoped<BlogService>();
        services.AddScoped<PostService>();
    }
}
