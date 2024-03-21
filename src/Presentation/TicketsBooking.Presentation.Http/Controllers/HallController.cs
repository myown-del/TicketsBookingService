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

    [HttpGet("/halls/{hallId}")]
    public ActionResult<Hall> GetHall([FromRoute] long hallId)
    {
        Hall? hall = _hallService.GetHall(hallId);

        if (hall is null)
            return new NotFoundResult();

        return hall;
    }

    [HttpDelete("/halls/{hallId}")]
    public ActionResult DeleteHall(int hallId)
    {
        Hall? hall = _hallService.GetHall(hallId);

        if (hall is null)
            return new NotFoundResult();

        _hallService.DeleteHall(hallId);
        return new OkResult();
    }

    [HttpPost("{venueId}/halls")]
    public ActionResult CreateHall(int venueId, [FromBody] Hall hall)
    {
        _hallService.CreateHall(hall);
        return new OkResult();
    }
}