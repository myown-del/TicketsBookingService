using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;
using TicketsBooking.Application.Abstractions.Services;
using TicketsBooking.Application.Models.Entities;

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
        return _seatService.GetAllSeats( hallId);
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

    [HttpPost("{venueId}/halls/{hallId}/seats")]
    public ActionResult CreateSeat(
        [FromRoute] int venueId,
        [FromRoute] int hallId,
        [FromBody] Seat seat)
    {
        _seatService.CreateSeat(seat);
        return new OkResult();
    }
}