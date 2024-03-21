using Microsoft.EntityFrameworkCore;
using TicketsBooking.Application.Abstractions.Persistence.Repositories;
using TicketsBooking.Application.Models.Entities;
using TicketsBooking.Infrastructure.Persistence.Contexts;
using TicketsBooking.Infrastructure.Persistence.Models;

namespace TicketsBooking.Infrastructure.Persistence.Repositories;

public class UserRepository : RepositoryBase<User, UserModel>, IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    protected override DbSet<UserModel> DbSet => _context.Users;

    public User? GetById(int id)
    {
        UserModel? user = DbSet.FirstOrDefault(v => v.Id == id);
        return user != null ? MapTo(user) : null;
    }

    public User? GetByPhoneNumber(string phoneNumber)
    {
        UserModel? user = DbSet.FirstOrDefault(v => v.PhoneNumber == phoneNumber);
        return user != null ? MapTo(user) : null;
    }

    public User? GetByRefreshToken(string refreshToken)
    {
        UserModel? user = DbSet.FirstOrDefault(v => v.RefreshToken == refreshToken);
        return user != null ? MapTo(user) : null;
    }

    public void ChangeUser(int id, string? name = null, string? email = null, DateTime? birthdayDate = null)
    {
        UserModel? user = DbSet.FirstOrDefault(v => v.Id == id);
        if (user != null) DbSet.Remove(user);
        if (name != null) user!.Name = name;
        if (email != null) user!.Email = email;
        if (birthdayDate != null) user!.BirthdayDate = birthdayDate;
        if (user != null) DbSet.Add(user);
        _context.SaveChanges();
    }

    protected override UserModel MapFrom(User entity)
    {
        return new UserModel(
            entity.Id,
            entity.Name,
            entity.Email,
            entity.BirthdayDate,
            entity.PhoneNumber,
            entity.PasswordHash,
            entity.IsAdmin,
            entity.RefreshToken,
            entity.RefreshTokenExpiresAt);
    }

    protected User MapTo(UserModel model)
    {
        return new User(
            phoneNumber: model.PhoneNumber,
            passwordHash: model.PasswordHash,
            refreshToken: model.RefreshToken,
            refreshTokenExpiresAt: model.RefreshTokenExpiresAt,
            id: model.Id,
            name: model.Name,
            email: model.Email,
            birthdayDate: model.BirthdayDate,
            model.IsAdmin);
    }

    protected override bool Equal(User entity, UserModel model)
    {
        throw new NotImplementedException();
    }

    protected override void UpdateModel(UserModel model, User entity)
    {
        throw new NotImplementedException();
    }
}