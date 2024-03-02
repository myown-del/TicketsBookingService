using Newtonsoft.Json.Linq;

namespace TicketsBooking.Application.Abstractions.Persistence.Repositories;

public interface IGetAllTickets
{
    public JArray GetAllSeats(int showID, int sessionID, bool onlyAvailable);
}