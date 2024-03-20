using System.ComponentModel.DataAnnotations.Schema;
using TicketsBooking.Application.Models.Entities;

namespace TicketsBooking.Infrastructure.Persistence.Models;

public class ShowModel
{
    public ShowModel(int id, string? title, string? genre, string? director, string? duration, ShowType type)
    {
        Id = id;
        Title = title;
        Genre = genre;
        Director = director;
        Duration = duration;
        Type = type;
    }

    [Column("id")]
    public int Id { get; set; }

    [Column("title")]
    public string? Title { get; set; }

    [Column("genre")]
    public string? Genre { get; set; }

    [Column("director")]
    public string? Director { get; set; }

    [Column("duration")]
    public string? Duration { get; set; }

    [Column("type")]
    public ShowType Type { get; set; }
}