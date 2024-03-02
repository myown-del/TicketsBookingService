namespace TicketsBooking.Application.Abstractions.Persistence.Repositories;

public interface IAuthorization
{
    public string Registration(string phoneNumber, string password);
}