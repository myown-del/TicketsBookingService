namespace TicketsBooking.Application.Abstractions.Persistence.Repositories;

public interface IUser
{
    public Dictionary<string, string> Registration(string phoneNumber, string password, string name, string email, DateTime birthdayDate, bool isAdmin);

    public Dictionary<string, string> Authorisation(string phoneNumber, string password);

    public Dictionary<string, string> UpdatingToken(string token);
}