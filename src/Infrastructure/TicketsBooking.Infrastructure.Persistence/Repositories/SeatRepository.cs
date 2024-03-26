using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using TicketsBooking.Application.Abstractions.Persistence.Repositories;
using TicketsBooking.Application.Models.Dto;
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
        return new SeatModel(entity.Id, entity.Hall!.Id, entity.Row, entity.Number);
    }

    protected override bool Equal(Seat entity, SeatModel model)
    {
        return entity.Id.Equals(model.Id);
    }

    protected override void UpdateModel(SeatModel model, Seat entity)
    {
        model.Id = entity.Id;
        model.HallId = entity.Hall!.Id;
        model.Row = entity.Row;
        model.Number = entity.Number;
    }

    public Collection<Seat> GetAll(int hallId)
    {
        IEnumerable<SeatModel> seats = _context.Seats.Where(seat => seat.Hall!.Id == hallId)
            .Include(seat => seat.Hall)
            .ThenInclude(hall => hall!.Venue)
            .ToList();
        return new Collection<Seat>(seats.Select(MapTo).ToList());
    }

    public Seat? GetSeat(int seatId)
    {
        SeatModel? seat = _context.Seats.
            Include(seat => seat.Hall).
            ThenInclude(hall => hall!.Venue).
            FirstOrDefault(seat => seat.Id == seatId);

        if (seat is null)
            return null;

        return MapTo(seat);
    }

    public Seat Add(SeatDto seatDto)
    {
        var seatModel = new SeatModel()
        {
            Row = seatDto.Row,
            Number = seatDto.Number,
            HallId = seatDto.HallId,
        };

        DbSet.Add(seatModel);
        _context.SaveChanges();

        HallModel? hall = _context.Halls.
            Include(hall => hall.Venue).
            FirstOrDefault(hall => hall.Id == seatDto.HallId);
        seatModel.Hall = hall;

        return MapTo(seatModel);
    }

    public void Remove(int seatId)
    {
        SeatModel? seat = DbSet.FirstOrDefault(x => x.Id == seatId);

        if (seat is not null)
        {
            DbSet.Remove(seat);
            _context.SaveChanges();
        }
    }

    protected Seat MapTo(SeatModel model)
    {
        return new Seat(model.Id, model.Hall!.MapTo(), model.Row, model.Number);
    }
}