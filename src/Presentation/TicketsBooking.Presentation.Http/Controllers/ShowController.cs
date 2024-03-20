using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;
using TicketsBooking.Application.Abstractions.Services;
using TicketsBooking.Application.Models.Entities;

namespace TicketsBooking.Presentation.Http.Controllers;

[ApiController]
[Route("api/shows")]
public class ShowController : ControllerBase
{
    private readonly IShowService _showService;

    public ShowController(IShowService showService)
    {
        _showService = showService;
    }

    [HttpPost("")]
    public ActionResult CreateShow([FromBody] Show show)
    {
        _showService.CreateShow(show);
        return new OkResult();
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteShow(int showId)
    {
        _showService.DeleteShow(showId);
        return new OkResult();
    }

    [HttpGet("")]
    public ActionResult<Collection<Show>> GetAllShows(ShowType showType)
    {
        Collection<Show> shows = _showService.GetAllShows(showType);
        return shows;
    }
}