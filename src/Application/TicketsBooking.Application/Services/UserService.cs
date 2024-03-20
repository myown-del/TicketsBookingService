using TicketsBooking.Application.Abstractions.Services;

namespace TicketsBooking.Application.Services;

public class UserService : IUserService
{
    public void ChangeUser(string? name = null, string? email = null, DateTime? birthdayDate = null)
    {
        throw new NotImplementedException();
    }
}