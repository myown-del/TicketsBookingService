namespace TicketsBooking.Application.Models.Entities;

public class Seat
{
    public Seat(int id, int hallId, int venueId, int row, int number)
    {
        Id = id;
        HallId = hallId;
        VenueId = venueId;
        Row = row;
        Number = number;
    }

    public int Id { get; set; }

    public int HallId { get; set; }

    public int VenueId { get; set; }

    public int Number { get; set; }

    public int Row { get; set; }
}