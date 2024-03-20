using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TicketsBooking.Application.Abstractions.Persistence;
using TicketsBooking.Application.Abstractions.Persistence.Repositories;
using TicketsBooking.Infrastructure.Persistence.Contexts;
using TicketsBooking.Infrastructure.Persistence.Repositories;

namespace TicketsBooking.Infrastructure.Persistence.Extensions;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructurePersistence(this IServiceCollection collection, IConfiguration configuration)
    {
        collection.AddContext(configuration);

        // collection.AddPlatformPostgres(builder => builder.BindConfiguration("Infrastructure:Persistence:Postgres"));
        // collection.AddSingleton<IDataSourcePlugin, MappingPlugin>();
        //
        // collection.AddPlatformMigrations(typeof(IAssemblyMarker).Assembly);
        // collection.AddHostedService<MigrationRunnerService>();
        collection.AddScoped<IPersistenceContext, PersistenceContext>();
        collection.AddScoped<IVenueRepository, VenueRepository>();
        collection.AddScoped<IHallRepository, HallRepository>();
        collection.AddScoped<IUserRepository, UserRepository>();

        // collection.AddScoped<IShowRepository, ShowRepository>();
        return collection;
    }

    private static IServiceCollection AddContext(this IServiceCollection collection, IConfiguration configuration)
    {
        collection.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(configuration.GetSection("Infrastructure:Persistence:Postgres:ConnectionString").Value));
        return collection;
    }
}