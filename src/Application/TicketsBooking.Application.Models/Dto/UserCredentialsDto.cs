namespace TicketsBooking.Application.Models.Dto;

public class UserCredentialsDto
{
    public UserCredentialsDto(string phoneNumber, string password)
    {
        PhoneNumber = phoneNumber;
        Password = password;
    }

    public string PhoneNumber { get; set; }

    public string Password { get; set; }
}