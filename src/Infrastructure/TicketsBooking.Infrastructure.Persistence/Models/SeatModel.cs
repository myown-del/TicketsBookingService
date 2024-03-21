using System.ComponentModel.DataAnnotations.Schema;

namespace TicketsBooking.Infrastructure.Persistence.Models;

public class SeatModel
{
    public SeatModel(int id, int hallId, int row, int number)
    {
        Id = id;
        HallId = hallId;
        Row = row;
        Number = number;
    }

    [Column("id")]
    public int Id { get; set; }

    [Column("hall_id")]
    public int HallId { get; set; }
    
    [Column("row")]
    public int Row { get; set; }
    
    [Column("number")]
    public int Number { get; set; }
}