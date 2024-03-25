using TicketsBooking.Application.Models.Entities;

namespace TicketsBooking.Presentation.Http.Models.Shows;

public class ShowDto
{
    public ShowDto(int id, string? title, string? genre, string? director, string? duration, ShowType type)
    {
        Id = id;
        Title = title;
        Genre = genre;
        Director = director;
        Duration = duration;
        Type = type.ToString().ToLower();
    }

    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Genre { get; set; }

    public string? Director { get; set; }

    public string? Duration { get; set; }

    public string? Type { get; set; }
}