using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TicketsBooking.Application.Abstractions.Services;
using TicketsBooking.Application.Helpers;
using TicketsBooking.Application.Services;

namespace TicketsBooking.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection, IConfiguration configuration)
    {
        AuthenticationHelper.SetConfig(configuration);

        collection.AddScoped<IVenueService, VenueService>();
        collection.AddScoped<IHallService, HallService>();
        collection.AddScoped<IUserService, UserService>();
        collection.AddScoped<IAuthenticationService, AuthenticationService>();
        collection.AddScoped<ISeatService, SeatService>();
        return collection;
    }
}