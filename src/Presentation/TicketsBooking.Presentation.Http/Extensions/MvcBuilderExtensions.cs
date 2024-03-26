namespace TicketsBooking.Presentation.Http.Extensions;

public static class MvcBuilderExtensions
{
    public static IMvcBuilder AddPresentationHttp(this IMvcBuilder builder)
    {
        // builder.AddJsonOptions(opts =>
        // {
        //     var enumConverter = new JsonStringEnumConverter();
        //     opts.JsonSerializerOptions.Converters.Add(enumConverter);
        // });
        return builder.AddApplicationPart(typeof(IAssemblyMarker).Assembly);
    }
}