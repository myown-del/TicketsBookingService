namespace TicketsBooking.Application.Models.Entities;

public class Show
{
    public Show(int id, string? title, string? genre, string? director, string? duration, ShowType type)
    {
        Id = id;
        Title = title;
        Genre = genre;
        Director = director;
        Duration = duration;
        Type = type;
    }

    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Genre { get; set; }

    public string? Director { get; set; }

    public string? Duration { get; set; }

    public ShowType Type { get; set; }
}