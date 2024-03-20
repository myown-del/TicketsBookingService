using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using TicketsBooking.Application.Abstractions.Persistence.Repositories;
using TicketsBooking.Application.Models.Entities;
using TicketsBooking.Infrastructure.Persistence.Contexts;
using TicketsBooking.Infrastructure.Persistence.Models;

namespace TicketsBooking.Infrastructure.Persistence.Repositories;

public class SessionRepository : RepositoryBase<Session, SessionModel>, ISessionRepository
{
    private readonly ApplicationDbContext _context;

    public SessionRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    protected override DbSet<SessionModel> DbSet => _context.Sessions;

    public Session? GetById(int id)
    {
        SessionModel? session = DbSet.FirstOrDefault(x => x.Id == id);

        if (session is null)
            return null;

        return MapTo(session);
    }

    public void RemoveById(int sessionId)
    {
        SessionModel? session = DbSet.FirstOrDefault(v => v.Id == sessionId);
        if (session != null)
        {
            DbSet.Remove(session);
            _context.SaveChanges();
        }
    }

    public Collection<Session> GetAllByParametrs(int showId, int venueId, DateTime fromDate, DateTime toDate)
    {
        throw new NotImplementedException();
    }

    protected VenueModel MapFrom(Venue entity)
    {
        throw new NotImplementedException();
    }

    protected bool Equal(Venue entity, VenueModel model)
    {
        throw new NotImplementedException();
    }

    protected void UpdateModel(VenueModel model, Venue entity)
    {
        throw new NotImplementedException();
    }

    protected Session MapTo(SessionModel model)
    {
        return new Session(model.Id, model.ShowId, model.HallId, model.Date);
    }

    protected override SessionModel MapFrom(Session entity)
    {
        return new SessionModel(
            entity.Id,
            entity.ShowId,
            entity.HallId,
            entity.Date);
    }

    protected override bool Equal(Session entity, SessionModel model)
    {
        return entity.Id.Equals(model.Id);
    }

    protected override void UpdateModel(SessionModel model, Session entity)
    {
        model.Id = entity.Id;
        model.ShowId = entity.ShowId;
        model.HallId = entity.HallId;
        model.Date = entity.Date;
    }
}