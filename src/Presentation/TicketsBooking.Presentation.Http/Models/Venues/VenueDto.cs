using TicketsBooking.Application.Models.Entities;

namespace TicketsBooking.Presentation.Http.Models.Venues;
    public class VenueDto
    {
        public VenueDto(long id, string name, string address, VenueType type, string city)
        {
            Id = id;
            Name = name;
            Address = address;
            Type = type.ToString().ToLower();
            City = city;
        }

        public long Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Type { get; set; }

        public string City { get; set; }
    }


