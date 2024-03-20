namespace TicketsBooking.Application.Models.Entities;

public class User
{
    public User(
        string phoneNumber,
        string passwordHash,
        string refreshToken,
        DateTime refreshTokenExpiresAt,
        long? id = null,
        string? name = null,
        string? email = null,
        DateTime? birthdayDate = null,
        bool isAdmin = false)
    {
        Id = id;
        Name = name;
        Email = email;
        BirthdayDate = birthdayDate;
        PhoneNumber = phoneNumber;
        PasswordHash = passwordHash;
        RefreshToken = refreshToken;
        RefreshTokenExpiresAt = refreshTokenExpiresAt;
        IsAdmin = isAdmin;
    }

    public long? Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public DateTime? BirthdayDate { get; set; }

    public string PhoneNumber { get; set; }

    public string PasswordHash { get; set; }

    public bool IsAdmin { get; set; }

    public string RefreshToken { get; set; }

    public DateTime RefreshTokenExpiresAt { get; set; }
}