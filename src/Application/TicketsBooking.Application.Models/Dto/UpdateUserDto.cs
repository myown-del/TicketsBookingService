namespace TicketsBooking.Application.Models.Dto;

public class UpdateUserDto
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public DateTime BirthdayDate { get; set; }
}