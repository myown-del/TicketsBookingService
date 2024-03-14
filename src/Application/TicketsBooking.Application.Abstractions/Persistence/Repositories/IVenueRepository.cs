using System.Collections.ObjectModel;
using TicketsBooking.Application.Models.Entities;

namespace TicketsBooking.Application.Abstractions.Persistence.Repositories;

public interface IVenueRepository
{
    public Venue? GetById(int id);

    public Collection<Venue> GetAll(string? type = null);

    public void Add(Venue venue);
}