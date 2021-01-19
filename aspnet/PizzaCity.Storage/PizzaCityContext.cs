using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PizzaCity.Domain.Models;

namespace PizzaBox.Storage
{
  public class PizzaCityContext : DbContext
  {
    public DbSet<Order> Orders { get; set; }
    public DbSet<Store> Stores { get; set; }

    public PizzaCityContext(DbContextOptions<PizzaCityContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Order>().HasKey(o => o.EntityId);
      builder.Entity<Store>().HasKey(s => s.EntityId);

      builder.Entity<Store>().HasData(
        new Store() { EntityId = 1, Name = "Pizza City" },
        new Store() { EntityId = 2, Name = "Pizza City 2" },
        new Store() { EntityId = 3, Name = "Pizza City 3" }
      );