namespace TicketsBooking.Application.Models.Entities;

public class User
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public DateTime BirthdayDate { get; set; }
    public string? Login { get; set; }
    public string? PasswordHash { get; set; }
    public bool IsAdmin { get; set; }
}