using Newtonsoft.Json.Linq;

namespace TicketsBooking.Application.Abstractions.Persistence.Repositories;

public interface IGetAllSeats
{
    public JArray GetAllSeats(int venueID, int hallID);
}