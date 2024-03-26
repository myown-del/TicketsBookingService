using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using TicketsBooking.Application.Abstractions.Persistence.Repositories;
using TicketsBooking.Application.Models.Entities;
using TicketsBooking.Infrastructure.Persistence.Contexts;
using TicketsBooking.Infrastructure.Persistence.Models;

namespace TicketsBooking.Infrastructure.Persistence.Repositories;

public class ShowRepository : RepositoryBase<Show, ShowModel>, IShowRepository
{
    private readonly ApplicationDbContext _context;

    public ShowRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public void CreateShow(Show show)
    {
        Add(show);
    }

    public void DeleteShow(int showId)
    {
        ShowModel? show = DbSet.FirstOrDefault(x => x.Id == showId);

        if (show is not null)
        {
            DbSet.Remove(show);
            _context.SaveChanges();
        }
    }

    public Collection<Show> GetAllShows(ShowType showType)
    {
        IEnumerable<ShowModel> shows = DbSet.ToList().Where(x => x.Type == showType);
        return new Collection<Show>(shows.Select(MapTo).ToList());
    }

    protected override DbSet<ShowModel> DbSet => _context.Shows;

    protected Show MapTo(ShowModel model)
    {
        return new Show(model.Id, model.Title, model.Genre, model.Director, model.Duration, model.Type);
    }

    protected override ShowModel MapFrom(Show entity)
    {
        return new ShowModel(entity.Id, entity.Title, entity.Genre, entity.Director, entity.Duration, entity.Type);
    }

    protected override bool Equal(Show entity, ShowModel model)
    {
        return entity.Id.Equals(model.Id);
    }

    protected override void UpdateModel(ShowModel model, Show entity)
    {
        model.Id = entity.Id;
        model.Title = entity.Title;
        model.Genre = entity.Genre;
        model.Director = entity.Director;
        model.Duration = entity.Duration;
        model.Type = entity.Type;
    }
}