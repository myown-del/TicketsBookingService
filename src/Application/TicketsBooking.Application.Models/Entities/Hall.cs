namespace TicketsBooking.Application.Models.Entities;

public class Hall
{
    public long Id { get; set; }

    public long TheaterId { get; set; }

    public string? HallNumber { get; set; }
}