using TicketsBooking.Application.Models.Entities;

namespace TicketsBooking.Application.Abstractions.Persistence.Repositories;

public interface IUserRepository
{
    public User? GetById(int id);

    public void Add(User user);

    public User? GetByPhoneNumber(string phoneNumber);

    public User? GetByRefreshToken(string refreshToken);

    public void ChangeUser(
        int id,
        string? name = null,
        string? email = null,
        DateTime? birthdayDate = null);
}