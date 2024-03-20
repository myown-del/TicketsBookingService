namespace TicketsBooking.Application.Models.Dto;

public class UserRegister
{
    public UserRegister(string phoneNumber, string password)
    {
        PhoneNumber = phoneNumber;
        Password = password;
    }

    public string PhoneNumber { get; set; }

    public string Password { get; set; }
}