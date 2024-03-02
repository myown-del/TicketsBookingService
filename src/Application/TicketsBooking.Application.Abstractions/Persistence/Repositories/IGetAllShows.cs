using Newtonsoft.Json.Linq;

namespace TicketsBooking.Application.Abstractions.Persistence.Repositories;

public interface IGetAllShows
{
    public JArray GetAllSeats(int venueID, string showType);
}