using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using TicketsBooking.Application.Abstractions.Persistence.Repositories;
using TicketsBooking.Application.Models.Entities;
using TicketsBooking.Infrastructure.Persistence.Contexts;
using TicketsBooking.Infrastructure.Persistence.Models;

namespace TicketsBooking.Infrastructure.Persistence.Repositories;

public class VenueRepository : RepositoryBase<Venue, VenueModel>, IVenueRepository
{
    private readonly ApplicationDbContext _context;

    public VenueRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public Venue? GetById(int id)
    {
        VenueModel? venue = DbSet.FirstOrDefault(v => v.Id == id);
        return venue != null ? MapTo(venue) : null;
    }

    public void RemoveById(int id)
    {
        VenueModel? venue = DbSet.FirstOrDefault(v => v.Id == id);
        if (venue != null)
        {
            DbSet.Remove(venue);
            _context.SaveChanges();
        }
    }

    public Collection<Venue> GetAll(VenueType? type = null)
    {
        List<VenueModel> venues;

        if (type != null)
        {
            venues = DbSet.Where(v => v.Type.ToLower() == type.ToString()!.ToLower()).ToList();
        }
        else
        {
            venues = DbSet.ToList();
        }

        return new Collection<Venue>(venues.Select(MapTo).ToList());
    }

    protected override DbSet<VenueModel> DbSet => _context.Venues;

    protected override VenueModel MapFrom(Venue entity)
    {
        return new VenueModel(
            entity.Id,
            entity.Name,
            entity.Address,
            entity.Type.ToString().ToLower(),
            entity.City);
    }

    protected Venue MapTo(VenueModel model)
    {
        var type = (VenueType)Enum.Parse(typeof(VenueType), model.Type, true);
        return new Venue(model.Id, model.Name, model.Address, type, model.City);
    }

    protected override bool Equal(Venue entity, VenueModel model)
    {
        return entity.Id.Equals(model.Id);
    }

    protected override void UpdateModel(VenueModel model, Venue entity)
    {
        model.Id = entity.Id;
        model.Address = entity.Address;
        model.Name = entity.Name;
        model.Type = entity.Type.ToString().ToLower();
        model.City = entity.City;
    }
}