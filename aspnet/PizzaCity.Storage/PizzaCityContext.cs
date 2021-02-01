using Microsoft.EntityFrameworkCore;
using PizzaCity.Domain.Models;
using PizzaCity.Domain.Abstracts;
using System.Collections.Generic;

namespace PizzaCity.Storage
{
  public class PizzaCityContext : DbContext
  {
    public DbSet<PizzaModel> MPizzas {get; set;}
    public DbSet<Customer> Customers{get; set;}
    public DbSet<Order> Orders { get; set; }
    public DbSet<Store> Stores { get; set; }
    public DbSet<Pizza> Pizzas{get; set;}
    public DbSet<Crust> Crusts{get; set;}
    public DbSet<Size> Sizes{get; set;}
    public DbSet<Toppings> Toppings{get; set;}
    public PizzaCityContext(DbContextOptions<PizzaCityContext> options) : base(options) { }
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
      builder.UseSqlServer("Server=tcp:monicap1.database.windows.net;Initial Catalog=PizzaCity-P1;User ID=sqladmin;Password={Katsuki8991*};");
    
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Order>().HasKey(o => o.EntityId);
      builder.Entity<Store>().HasKey(s => s.EntityId);
      builder.Entity<Customer>().HasKey(c => c.EntityId);
      builder.Entity<PizzaModel>().HasKey(m => m.EntityId);
      builder.Entity<Crust>().HasKey(r => r.EntityId);
      builder.Entity<Size>().HasKey(z => z.EntityId);
      builder.Entity<Toppings>().HasKey(t => t.EntityId);
      builder.Entity<Pizza>().HasKey(p => p.EntityId);
      SeedData(builder);

    }
    protected void SeedData(ModelBuilder builder)
    {
      builder.Entity<Store>().HasData(new List<Store>
      {
        new Store() { EntityId = 1, Name = "Pizza City" },
        new Store() { EntityId = 2, Name = "Pizza City 2" },
        new Store() { EntityId = 3, Name = "Pizza City 3" }
      }
      );

      builder.Entity<Crust>().HasData(new List<Crust>
      {
        new Crust() {Name = "Regular", Price = 0,EntityId=2},
        new Crust() {Name = "Garlic Butter", Price = 2.75,EntityId=4},
        new Crust() {Name = "Cheese Stuffed", Price = 6,EntityId=6}
      }
      );

      builder.Entity<Size>().HasData(new List<Size>
      {
        new Size() {Name = "Small", Price = 3.50, EntityId = 1},
        new Size() {Name = "Medium", Price = 5, EntityId = 2},
        new Size() {Name = "Large", Price = 8, EntityId = 3},
      }
      );

      builder.Entity<Toppings>().HasData(new List<Toppings>
      {
        new Toppings(){Name = "Mozzerella Cheese", Price = 0, EntityId = 1},
        new Toppings(){Name = "Parmesean Cheese", Price = 1, EntityId = 2},
        new Toppings(){Name = "Romano Cheese", Price = 2.50, EntityId = 3},
        new Toppings(){Name = "Pepperoni", Price = 4, EntityId = 4},
        new Toppings(){Name = "Italian Sausage", Price = 3, EntityId = 5},
        new Toppings(){Name = "Beef Sausage", Price = 5, EntityId = 6},
        new Toppings(){Name = "Onions", Price = 1, EntityId = 7},
        new Toppings(){Name = "Peppers", Price = 2, EntityId = 8},
        new Toppings(){Name = "Olives", Price = 3.75, EntityId = 9}
      }
      );

      builder.Entity<Customer>().HasData(new List<Customer>
      {
        new Customer(){Name = "Joshua", EntityId = 1},
        new Customer(){Name = "Dion", EntityId = 2}
      }
      );
    }
    
  }
}

