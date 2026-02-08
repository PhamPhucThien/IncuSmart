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
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();

        return services;
    }
}
