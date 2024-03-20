using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using TicketsBooking.Application.Abstractions.Persistence.Repositories;
using TicketsBooking.Application.Models.Entities;
using TicketsBooking.Infrastructure.Persistence.Contexts;
using TicketsBooking.Infrastructure.Persistence.Models;

namespace TicketsBooking.Infrastructure.Persistence.Repositories;

public class SeatRepository : RepositoryBase<Seat, SeatModel>, ISeatRepository
{
    private readonly ApplicationDbContext _context;

    public SeatRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    protected override DbSet<SeatModel> DbSet => _context.Seats;

    protected override SeatModel MapFrom(Seat entity)
    {
        return new SeatModel(entity.Id, entity.HallId, entity.VenueId, entity.Row, entity.Number);
    }

    protected override bool Equal(Seat entity, SeatModel model)
    {
        return entity.Id.Equals(model.Id);
    }

    protected override void UpdateModel(SeatModel model, Seat entity)
    {
        model.Id = entity.Id;
        model.HallId = entity.HallId;
        model.Row = entity.Row;
        model.Number = entity.Number;
    }

    public Collection<Seat> GetAll(int venueId, int hallId)
    {
        IEnumerable<SeatModel> seats = DbSet.ToList().Where(x => x.VenueId == venueId && x.HallId == hallId);
        return new Collection<Seat>(seats.Select(MapTo).ToList());
    }

    public Seat? GetSeat(int venueId, int hallId, int seatId)
    {
        SeatModel? seat = DbSet.FirstOrDefault(x => x.Id == hallId && x.VenueId == venueId && x.Id == seatId);

        if (seat is null)
            return null;

        return MapTo(seat);
    }

    public void Remove(int venueId, int hallId, int seatId)
    {
        SeatModel? seat = DbSet.FirstOrDefault(x => x.Id == hallId && x.VenueId == venueId && x.Id == seatId);

        if (seat is not null)
        {
            DbSet.Remove(seat);
            _context.SaveChanges();
        }
    }

    protected Seat MapTo(SeatModel model)
    {
        return new Seat(model.Id, model.HallId, model.VenueId, model.Row, model.Number);
    }
}