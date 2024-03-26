using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;
using TicketsBooking.Application.Abstractions.Services;
using TicketsBooking.Application.Models.Dto;
using TicketsBooking.Application.Models.Entities;
using TicketsBooking.Presentation.Http.Models.Seats;

namespace TicketsBooking.Presentation.Http.Controllers;

[ApiController]
[Route("api/venues")]
public class SeatController : ControllerBase
{
    private readonly ISeatService _seatService;

    public SeatController(ISeatService seatService)
    {
        _seatService = seatService;
    }

    [HttpGet("/halls/{hallId}/seats")]
    public ActionResult<Collection<Seat>> GetSeats([FromRoute] int hallId)
    {
        return _seatService.GetAllSeats(hallId);
    }

    [HttpDelete("/halls/seats/{seatId}")]
    public ActionResult DeleteSeat([FromRoute] int seatId)
    {
        Seat? seat = _seatService.GetSeat(seatId);

        if (seat is null)
            return new NotFoundResult();

        _seatService.DeleteSeat(seatId);
        return new OkResult();
    }

    [HttpPost("/halls/{hallId}/seats")]
    public ActionResult<Seat> CreateSeat([FromRoute] int hallId, [FromBody] CreateSeatModel createSeatModel)
    {
        var seatDto = new SeatDto()
        {
            HallId = hallId,
            Row = createSeatModel.Row,
            Number = createSeatModel.Number,
        };

        Seat seat = _seatService.CreateSeat(seatDto);

        return seat;
    }
}