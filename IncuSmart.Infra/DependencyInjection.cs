using IncuSmart.Application.Ports.Inbound;
using IncuSmart.Application.Ports.Outbound;
using IncuSmart.Application.Usecases;
using IncuSmart.Core.Utils;
using IncuSmart.Infra.Persistences;
using IncuSmart.Infra.Persistences.Mapper;
using IncuSmart.Infra.Persistences.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration config)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(
                config.GetConnectionString("DefaultConnection"))
                   .UseSnakeCaseNamingConvention());

        JwtOptions.Init
            (config
                .GetSection("Jwt")
                .Get<JwtOptionsDto>()!
            );

        // Inject use cases
        services.AddScoped<IAuthUseCase, AuthUseCase>();

        // Inject repositories
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}
