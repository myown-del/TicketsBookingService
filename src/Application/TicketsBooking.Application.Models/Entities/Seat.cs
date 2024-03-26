namespace TicketsBooking.Application.Models.Entities;

public class Seat
{
    public Seat(long id, Hall hall, int row, int number)
    {
        Id = id;
        Hall = hall;
        Row = row;
        Number = number;
    }

    public long Id { get; set; }

    public Hall? Hall { get; set; }

    public int Number { get; set; }

    public int Row { get; set; }
}