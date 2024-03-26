namespace TicketsBooking.Presentation.Http.Models.Sessions;
    public class SessionDto
    {
        public SessionDto(long id, long showId, long hallId, DateTime sessionDate)
        {
            Id = id;
            ShowId = showId;
            HallId = hallId;
            Date = sessionDate;
        }

        public long Id { get; set; }

        public long ShowId { get; set; }

        public long HallId { get; set; }

        public DateTime Date { get; set; }
    }


