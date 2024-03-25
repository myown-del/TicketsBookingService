using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;
using TicketsBooking.Application.Abstractions.Services;
using TicketsBooking.Application.Models.Entities;
using TicketsBooking.Infrastructure.Persistence.Exceptions;
using TicketsBooking.Presentation.Http.Models.Shows;

namespace TicketsBooking.Presentation.Http.Controllers;

[ApiController]
[Route("api/shows")]
public class ShowController(IShowService showService)
{
    [HttpPost("")]
    public ActionResult CreateShow([FromBody] Show show)
    {
        showService.CreateShow(show.Id, show.Title, show.Genre, show.Director, show.Duration, show.Type);
        return new OkResult();
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteShow(int showId)
    {
        try
        {
            showService.DeleteShow(showId);
        }
        catch (Exception e)
        {
            if (e is NotFoundException)
            {
                return new NotFoundResult();
            }
            return new BadRequestResult();
        }
        return new OkResult();
    }

    [HttpGet("")]
    public IEnumerable<ShowDto> GetAllShows(ShowType showType)
    {
        IEnumerable<Show> shows = showService.GetAllShows(showType);
        var response = new List<ShowDto>();
        foreach (var show in shows)
        {
            response.Add(new ShowDto(show.Id, show.Title, show.Genre, show.Director, show.Duration, show.Type));
        }
        return response;
    }
}