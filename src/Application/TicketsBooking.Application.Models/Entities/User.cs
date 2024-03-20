namespace TicketsBooking.Application.Models.Entities;

public class User
{
    public User(
        long id,
        string name,
        string email,
        DateTime birthdayDate,
        string login,
        string passwordHash,
        bool isAdmin)
    {
        Id = id;
        Name = name;
        Email = email;
        BirthdayDate = birthdayDate;
        Login = login;
        PasswordHash = passwordHash;
        IsAdmin = isAdmin;
    }

    public long Id { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }

    public DateTime BirthdayDate { get; set; }

    public string Login { get; set; }

    public string PasswordHash { get; set; }

    public bool IsAdmin { get; set; }
}