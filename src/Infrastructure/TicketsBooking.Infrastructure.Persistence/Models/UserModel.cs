using System.ComponentModel.DataAnnotations.Schema;

namespace TicketsBooking.Infrastructure.Persistence.Models;

public class UserModel
{
    public UserModel(long? id, string? name, string? email, DateTime? birthdayDate, string phoneNumber, string passwordHash, bool isAdmin)
    {
        Id = id;
        Name = name;
        Email = email;
        BirthdayDate = birthdayDate;
        PhoneNumber = phoneNumber;
        PasswordHash = passwordHash;
        IsAdmin = isAdmin;
    }

    [Column("id")]
    public long? Id { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("email")]
    public string? Email { get; set; }

    [Column("birthday_date")]
    public DateTime? BirthdayDate { get; set; }

    [Column("phone_number")]
    public string PhoneNumber { get; set; }

    [Column("password_hash")]
    public string PasswordHash { get; set; }

    [Column("is_admin")]
    public bool IsAdmin { get; set; }
}