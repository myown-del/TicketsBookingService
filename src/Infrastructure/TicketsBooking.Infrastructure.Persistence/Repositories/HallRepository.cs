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
        IEnumerable<HallModel> halls = DbSet.ToList().Where(x => x.VenueId == venueId);
        return new Collection<Hall>(halls.Select(MapTo).ToList());
    }

    public Hall? GetHall(long hallId)
    {
        HallModel? hall = DbSet.FirstOrDefault(x => x.Id == hallId);

        if (hall is null)
            return null;

        return MapTo(hall);
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
        return new HallModel(entity.Id, entity.Name, entity.VenueId);
    }

    protected override bool Equal(Hall entity, HallModel model)
    {
        return entity.Id.Equals(model.Id);
    }

    protected override void UpdateModel(HallModel model, Hall entity)
    {
        model.Id = entity.Id;
        model.VenueId = entity.VenueId;
        model.Name = entity.Name;
    }

    protected Hall MapTo(HallModel model)
    {
        return new Hall(model.Id, model.VenueId, model.Name);
    }
}