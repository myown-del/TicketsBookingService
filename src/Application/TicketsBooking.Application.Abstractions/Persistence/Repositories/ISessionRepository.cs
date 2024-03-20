using System.Collections.ObjectModel;
using TicketsBooking.Application.Models.Entities;

namespace TicketsBooking.Application.Abstractions.Persistence.Repositories;

public interface ISessionRepository
{
    public Session? GetById(int id);

    public Collection<Session> GetAllByParametrs(int showId, int venueId, DateTime fromDate, DateTime toDate);

    public void Add(int showId, int hallId, DateTime someDate);

    public void RemoveById(int sessionId);
}