namespace TicketsBooking.Application.Abstractions.Persistence.Repositories;

public interface ISeat
{
    public void DeleteSeat(int venueId, int hallId, int seatId);

    public void CreateSeat(int venueId, int hallId, int row, int number);

    public Dictionary<string, string> GetAllSeats(int venueId, int hallId);
}