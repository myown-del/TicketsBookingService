using Microsoft.AspNetCore.Mvc;
using TicketsBooking.Application.Abstractions.Services;
using TicketsBooking.Application.Models.Entities;
using TicketsBooking.Infrastructure.Persistence.Exceptions;
using TicketsBooking.Presentation.Http.Models.Venues;

namespace TicketsBooking.Presentation.Http.Controllers;

[ApiController]
[Route("api/venues")]
public class VenueController(IVenueService venueService)
{
    [HttpGet("")]
    public IEnumerable<VenueDto> GetVenues(VenueType? type = null)
    {
        IEnumerable<Venue> venues = venueService.GetAllVenues(type);
        var response = new List<VenueDto>();
        foreach (var venue in venues)
        {
            response.Add(new VenueDto(
                id: venue.Id,
                name: venue.Name,
                address: venue.Address,
                type: venue.Type,
                city: venue.City));
        }
        return response;
    }

    [HttpGet("{id}", Name = nameof(GetVenue))]
    public ActionResult<VenueDto?> GetVenue(int id)
    {
        Venue? venue = venueService.GetVenue(id);
        if (venue is null)
            return new NotFoundResult();
        
        var response = new VenueDto(
            id: venue.Id,
            name: venue.Name,
            address: venue.Address,
            type: venue.Type,
            city: venue.City);
        return response;
    }

    [HttpPost("")]
    public ActionResult CreateVenue([FromBody] VenueDto venue)
    {
        venueService.CreateVenue(
            id: venue.Id,
            name: venue.Name,
            address: venue.Address,
            type: Enum.Parse<VenueType>(venue.Type, ignoreCase: true),
            city: venue.City);
        return new OkResult();
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteVenue(int id)
    {
        try
        {
            venueService.DeleteVenue(id);
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
}