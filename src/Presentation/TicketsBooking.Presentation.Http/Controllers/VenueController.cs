using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;
using TicketsBooking.Application.Abstractions.Services;
using TicketsBooking.Application.Models.Entities;

namespace TicketsBooking.Presentation.Http.Controllers;

[ApiController]
[Route("api/venues")]
public class VenueController(IVenueService venueService)
{
    [HttpGet("")]
    public ActionResult<Collection<Venue>> GetVenues()
    {
        var venues = venueService.GetAllVenues();
        return venues;
    }

    [HttpGet("{id}", Name = nameof(GetVenue))]
    public ActionResult<Venue?> GetVenue(int id)
    {
        var venue = venueService.GetVenue(id);
        return venue;
    }

    [HttpPost("")]
    public ActionResult CreateVenue([FromBody] Venue venue)
    {
        venueService.CreateVenue(venue);
        return new OkResult();
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteVenue(int id)
    {
        venueService.DeleteVenue(id);
        return new OkResult();
    }
}