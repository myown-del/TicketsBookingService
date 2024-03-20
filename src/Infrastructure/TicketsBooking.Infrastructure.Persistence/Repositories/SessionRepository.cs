using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using TicketsBooking.Application.Abstractions.Persistence.Repositories;
using TicketsBooking.Application.Models.Entities;
using TicketsBooking.Infrastructure.Persistence.Contexts;
using TicketsBooking.Infrastructure.Persistence.Models;

namespace TicketsBooking.Infrastructure.Persistence.Repositories;

public class SessionRepository : RepositoryBase<Venue, VenueModel>, ISessionRepository
{
    private readonly ApplicationDbContext _context;
    
    public SessionRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
    
    public Session? GetById(int sessionId)
    {
        SessionModel? session = DbSet.FirstOrDefault(x => x.Id == sessionId);

        if (session is null)
            return null;

        return MapTo(session);
    }
    
    public void RemoveById(int id)
    {
        var session = DbSet.FirstOrDefault(v => v.Id == id);
        if (session != null)
        {
            DbSet.Remove(session);
            _context.SaveChanges();
        }
    }
    
    public void Add(int showId, int venueId, DateTime someDate)
    { 
        // дописать
    }

    public Collection<Session> GetAllByParametrs(int showId, int venueId, DateTime fromDate, DateTime toDate)
    { 
        // дописать
    }
    protected override DbSet<SessionModel> DbSet => _context.Session;
    
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