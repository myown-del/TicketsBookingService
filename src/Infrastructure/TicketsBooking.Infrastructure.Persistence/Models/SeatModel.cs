using System.ComponentModel.DataAnnotations.Schema;

namespace TicketsBooking.Infrastructure.Persistence.Models;

public class SeatModel
{
    public SeatModel(long id, long hallId, int row, int number)
    {
        Id = id;
        HallId = hallId;
        Row = row;
        Number = number;
    }
    
    public SeatModel()
    {}

    [Column("id")]
    public long Id { get; set; }

    [Column("hall_id")]
    public long HallId { get; set; }
    
    [Column("row")]
    public int Row { get; set; }
    
    [Column("number")]
    public int Number { get; set; }
    
    public HallModel? Hall { get; set; }
}