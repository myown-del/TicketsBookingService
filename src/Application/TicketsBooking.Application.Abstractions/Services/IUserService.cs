namespace TicketsBooking.Application.Abstractions.Services;

public interface IUserService
{
    public void ChangeUser(string? name = null, string? email = null, DateTime? birthdayDate = null);
}