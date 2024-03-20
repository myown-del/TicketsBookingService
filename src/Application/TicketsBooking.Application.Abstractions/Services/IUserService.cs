namespace TicketsBooking.Application.Abstractions.Services;

public interface IUserService
{
    public void ChangeUser(int id, string? name = null, string? email = null, DateTime? birthdayDate = null, string? phoneNumber = null);
}