using Newtonsoft.Json.Linq;

namespace TicketsBooking.Application.Abstractions.Persistence.Repositories;

public interface IGetAllHalls
{
    public JArray GetAllHalls(string type);
}