using Newtonsoft.Json.Linq;

namespace TicketsBooking.Application.Abstractions.Persistence.Repositories;

public interface IGetAllVenues
{
    public JArray GetAllVenues(string type);
}