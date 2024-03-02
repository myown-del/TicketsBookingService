namespace TicketsBooking.Application.Abstractions.Persistence.Repositories;

public interface ICreateVenue
{
    public void Create(int id, string type, string name, string address);
}