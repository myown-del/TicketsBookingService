using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;
using TicketsBooking.Application.Abstractions.Services;
using TicketsBooking.Application.Models.Entities;

namespace TicketsBooking.Presentation.Http.Controllers;

[ApiController]
[Route("api/venues")]
public class HallController : ControllerBase
{
    private readonly IHallService _hallService;

    public HallController(IHallService hallService)
    {
        _hallService = hallService;
    }

    [HttpGet("{venueId}/halls")]
    public ActionResult<Collection<Hall>> GetHalls([FromRoute] long venueId)
    {
        return _hallService.GetAllHalls(venueId);
    }

    [HttpGet("{venueId}/halls/{hallId}")]
    public ActionResult<Hall> GetHall([FromRoute] long venueId, [FromRoute] long hallId)
    {
        Hall? hall = _hallService.GetHall(venueId, hallId);

        if (hall is null)
            return new NotFoundResult();

        return hall;
    }

    [HttpDelete("{venueId}/halls/{hallId}")]
    public ActionResult DeleteHall(int venueId, int hallId)
    {
        Hall? hall = _hallService.GetHall(venueId, hallId);

        if (hall is null)
            return new NotFoundResult();

        _hallService.DeleteHall(hallId, venueId);
        return new OkResult();
    }

    [HttpPost("{venueId}/halls")]
    public ActionResult CreateHall(int venueId, [FromBody] Hall hall)
    {
        _hallService.CreateHall(hall);
        return new OkResult();
    }
}