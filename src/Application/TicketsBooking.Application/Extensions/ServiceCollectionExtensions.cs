using Microsoft.Extensions.DependencyInjection;
using TicketsBooking.Application.Abstractions.Services;
using TicketsBooking.Application.Services;

namespace TicketsBooking.Application.Extensions;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddScoped<IVenueService, VenueService>();
        collection.AddScoped<IHallService, HallService>();
        collection.AddScoped<IUserService, UserService>();
        collection.AddScoped<IAuthorizationService, AuthorizationService>();
        return collection;
    }
}