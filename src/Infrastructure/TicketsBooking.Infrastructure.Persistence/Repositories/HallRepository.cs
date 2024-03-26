using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using TicketsBooking.Application.Abstractions.Persistence.Repositories;
using TicketsBooking.Application.Models.Entities;
using TicketsBooking.Infrastructure.Persistence.Contexts;
using TicketsBooking.Infrastructure.Persistence.Models;

namespace TicketsBooking.Infrastructure.Persistence.Repositories;

public class HallRepository : RepositoryBase<Hall, HallModel>, IHallRepository
{
    private readonly ApplicationDbContext _context;

    public HallRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    protected override DbSet<HallModel> DbSet => _context.Halls;

    public Collection<Hall> GetAll(long venueId)
    {
        IEnumerable<HallModel> halls = _context.Halls.Where(hall => hall.VenueId == venueId)
            .Include(hall => hall.Venue)
            .ToList();
        return new Collection<Hall>(halls.Select(MapTo).ToList());
    }

    public Hall? GetHall(long hallId)
    {
        HallModel? hall = _context.Halls.Include(venue => venue.Venue).FirstOrDefault(hall => hall.Id == hallId);

        if (hall is null)
            return null;

        return MapTo(hall);
    }

    public Hall Add(string name, long venueId)
    {
        var hallModel = new HallModel()
        {
            Name = name,
            VenueId = venueId,
        };

        DbSet.Add(hallModel);
        _context.SaveChanges();

        VenueModel? venue = _context.Venues.FirstOrDefault(venue => venue.Id == venueId);
        hallModel.Venue = venue;

        return MapTo(hallModel);
    }

    public void Remove(long hallId)
    {
        HallModel? hall = DbSet.FirstOrDefault(x => x.Id == hallId);

        if (hall is not null)
        {
            DbSet.Remove(hall);
            _context.SaveChanges();
        }
    }

    protected override HallModel MapFrom(Hall entity)
    {
        return new HallModel(entity.Id, entity.Name!, entity.Venue!.Id);
    }

    protected override bool Equal(Hall entity, HallModel model)
    {
        return entity.Id.Equals(model.Id);
    }

    protected override void UpdateModel(HallModel model, Hall entity)
    {
        model.Id = entity.Id;
        model.VenueId = entity.Venue!.Id;
        model.Name = entity.Name!;
    }

    protected Hall MapTo(HallModel model)
    {
        return new Hall(model.Id, model.Venue!.MapTo(), model.Name!);
    }
}