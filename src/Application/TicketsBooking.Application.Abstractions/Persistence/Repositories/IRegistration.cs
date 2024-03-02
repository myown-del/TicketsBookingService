namespace TicketsBooking.Application.Abstractions.Persistence.Repositories;

public interface IRegistration
{
    public string Registration(string phoneNumber, string password);
}