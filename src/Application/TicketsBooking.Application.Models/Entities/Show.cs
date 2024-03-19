namespace TicketsBooking.Application.Models.Entities;

public class Show
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Genre { get; set; }

    public string? Director { get; set; }

    public string? Duration { get; set; }

    public ShowType Type { get; set; }
}