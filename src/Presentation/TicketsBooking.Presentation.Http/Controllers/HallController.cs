using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;
using TicketsBooking.Application.Abstractions.Services;
using TicketsBooking.Application.Models.Entities;
using TicketsBooking.Presentation.Http.Models.Halls;

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
    public ActionResult DeleteHall([FromRoute] int hallId)
    {
        Hall? hall = _hallService.GetHall(hallId);

        if (hall is null)
            return new NotFoundResult();

        _hallService.DeleteHall(hallId);
        return new OkResult();
    }

    [HttpPost("{venueId}/halls")]
    public ActionResult<Hall> CreateHall([FromRoute] int venueId, [FromBody] CreateHallModel createHallModel)
    {
        
        Hall hall = _hallService.CreateHall(createHallModel.Name, venueId);
        
        return hall;
    }
}