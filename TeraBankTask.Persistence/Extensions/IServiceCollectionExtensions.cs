using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TeraBankTask.Aplication.Interfaces;
using TeraBankTask.Persistence.DataContext;
using TeraBankTask.Persistence.Repositories;

namespace TeraBankTask.Persistence.Extensions;

public static class IServiceCollectionExtensions
{
    public static void AddPersistenceLayer(this IServiceCollection services , IConfiguration configuration)
    {
        services.AddDbContext(configuration);
        services.AddRepositories();
    }

    public static void AddDbContext(this IServiceCollection services , IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("TeraBankDbConnstring");

        services.AddDbContext<TeraBankTaskDbContext>(options =>
        options.UseSqlServer(connectionString ,
               builder => builder.MigrationsAssembly(typeof(TeraBankTaskDbContext).Assembly.FullName)));
    }

    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped(typeof(IUnitOfWork) , typeof(UnitOfWork))
                .AddScoped<IUserRepository , UserRepository>()
                .AddScoped<ITransactionRepository , TransactionRepository>();
    }
}
