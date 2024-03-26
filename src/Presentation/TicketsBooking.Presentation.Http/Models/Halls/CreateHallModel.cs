namespace TicketsBooking.Presentation.Http.Models.Halls;

public class CreateHallModel
{
    public CreateHallModel(string name)
    {
        Name = name;
    }

    public string Name { get; set; }
}