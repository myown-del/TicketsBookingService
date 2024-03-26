using TicketsBooking.Application.Abstractions.Services;

namespace TicketsBooking.Application.Services;

public class UserService : IUserService
{
    private readonly IUserService _userRepository;

    public UserService(IUserService showRepository)
    {
        _userRepository = showRepository;
    }
    
    public void ChangeUser(int id, string? name = null, string? email = null, DateTime? birthdayDate = null, string? phoneNumber = null)
    {
        _userRepository.ChangeUser(id, name, email, birthdayDate, phoneNumber);
    }
}