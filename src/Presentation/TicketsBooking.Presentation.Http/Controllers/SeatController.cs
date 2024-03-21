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

    [HttpGet("{venueId}/halls/{hallId}/seats")]
    public ActionResult<Collection<Seat>> GetSeats([FromRoute] int venueId, [FromRoute] int hallId)
    {
        return _seatService.GetAllSeats(venueId, hallId);
    }

    [HttpDelete("{venueId}/halls/{hallId}/seats/{seatId}")]
    public ActionResult DeleteSeat([FromRoute] int venueId, [FromRoute] int hallId, [FromRoute] int seatId)
    {
        Seat? seat = _seatService.GetSeat(venueId, hallId, seatId);

        if (seat is null)
            return new NotFoundResult();

        _seatService.DeleteSeat(venueId, hallId, seatId);
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