﻿using Microsoft.EntityFrameworkCore;
using TicketsBooking.Infrastructure.Persistence.Models;

namespace TicketsBooking.Infrastructure.Persistence.Contexts;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext() { }

    public ApplicationDbContext(DbContextOptions options) : base(options) { }

    public DbSet<VenueModel> Venues { get; protected init; } = null!;

    public DbSet<HallModel> Halls { get; protected init; } = null!;

    public DbSet<ShowModel> Shows { get; protected init; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        modelBuilder.Entity<VenueModel>().ToTable("venues", t => t.ExcludeFromMigrations());
        modelBuilder.Entity<HallModel>().ToTable("halls", t => t.ExcludeFromMigrations());
        modelBuilder.Entity<ShowModel>().ToTable("shows", t => t.ExcludeFromMigrations());
        base.OnModelCreating(modelBuilder);
    }
}