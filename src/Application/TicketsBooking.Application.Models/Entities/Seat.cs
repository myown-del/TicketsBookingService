namespace TicketsBooking.Application.Models.Entities;

public class Seat
{
    public long Id { get; set; }
    public long HallId { get; set; }
    public long SeatPlace { get; set; }
    public long Row { get; set; }
}