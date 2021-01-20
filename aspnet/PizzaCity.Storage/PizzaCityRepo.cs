using System;
using System.Collections.Generic;
using System.Linq;
using PizzaCity.Domain.Abstracts;
using PizzaCity.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace PizzaCity.Storage
{
  public class PizzaCityRepo
  {
    private PizzaCityContext _ctx;

    public PizzaCityRepo(PizzaCityContext context)
    {
      _ctx = context;
    }

    public List<string> GetStores()
    {
      return _ctx.Stores.Select(s => s.Name).ToList();
    } 

    public List<string> GetPizza()
    {
      return _ctx.Pizzas.Select(p => p.Name).ToList();
    }

    public List<string> GetCustomer()
    {
      return _ctx.Customers.Select(c => c.Name).ToList();
    }

    public IEnumerable<Store> ReadStores()
    {

        return _ctx.Stores
                    .Include(u => u.Orders).ThenInclude(o => o.Pizzas).ThenInclude(p => p.Toppings)
                    .Include(u => u.Orders).ThenInclude(o => o.Pizzas).ThenInclude(p => p.Crust)
                    .Include(u => u.Orders).ThenInclude(o => o.Pizzas).ThenInclude(p => p.Size)
                    .Include(u => u.Orders).ThenInclude(o => o.Store)
                    .ToList();
 
    }
    public IEnumerable<Order> StoreOrders(string storeName)
    {
        return _ctx.Stores
                    .Include(u => u.Orders).ThenInclude(o => o.Pizzas).ThenInclude(p => p.Toppings)
                    .Include(u => u.Orders).ThenInclude(o => o.Pizzas).ThenInclude(p => p.Crust)
                    .Include(u => u.Orders).ThenInclude(o => o.Pizzas).ThenInclude(p => p.Size)
                    .Include(u => u.Orders).ThenInclude(o => o.Customer)
                    .FirstOrDefault(s=>s.Name==storeName).Orders;
    }
    public IEnumerable<PizzaModel> ReadPizzas()
    {
        return _ctx.MPizzas.ToList();
    }
    public IEnumerable<Order> ReadOrders()
    {
        return _ctx.Orders.Include(o=>o.Pizzas)
                            .ToList();
                            
    }
    public IEnumerable<Pizza> ReadPizza()
    {
        return _ctx.Pizzas.Include(p=>p.Crust)
                                  .Include(p=>p.Size)
                                  .Include(p=>p.Toppings);
    }
    public IEnumerable<Crust> ReadCrust()
    {
        return _ctx.Crusts.ToList();
    }
    public IEnumerable<Toppings> ReadToppings()
    {
        return _ctx.Toppings.ToList();
    }
    public IEnumerable<Customer> ReadCustomers()
    {
        var users = _ctx.Customers
                    .Include(u => u.Orders).ThenInclude(o => o.Pizzas).ThenInclude(p => p.Toppings)
                    .Include(u => u.Orders).ThenInclude(o => o.Pizzas).ThenInclude(p => p.Crust)
                    .Include(u => u.Orders).ThenInclude(o => o.Pizzas).ThenInclude(p => p.Size)
                    .Include(u => u.Orders).ThenInclude(o => o.Store)
                    .ToList();
        return users;
    }
    public IEnumerable<Size> ReadSize()
    {
        return _ctx.Sizes.ToList();
    }   
    public void Save(Store store)
    {
      _ctx.Stores.Add(store); 
      _ctx.Database.OpenConnection();
    try
    {
        _ctx.SaveChanges();
    }
    finally
    {
        _ctx.Database.CloseConnection();
    }
    }
    public void Save(Order order)
    {
        _ctx.Orders.Add(order);
    try
    {
        _ctx.SaveChanges();
    }
    finally
    {
        _ctx.Database.CloseConnection();
    }
    }
    public void Save(Pizza pizza)
    {
        _ctx.Pizzas.Add(pizza);
    try
    {
        _ctx.SaveChanges();
    }
    finally
    {
        _ctx.Database.CloseConnection();
    }
    }
    public void Save(Customer customer)
    {
        _ctx.Customers.Add(customer);
        _ctx.Database.OpenConnection();
        try
        {
            _ctx.SaveChanges();
        }
        finally
        {
            _ctx.Database.CloseConnection();
        }
    }
    public void Save(PizzaModel pizza)
    {
        _ctx.MPizzas.Add(pizza);
        _ctx.Database.OpenConnection();
    try
    {
        _ctx.SaveChanges();
    }
    finally
    {
        _ctx.Database.CloseConnection();
    }
    }
    // Save changes 
    public void UpdateCustomer(Customer customer)
    {
        var u =  _ctx.Customers.ToList().FirstOrDefault(x => x.Name==customer.Name);
        if(u==null)
        {
            System.Console.WriteLine("Name does not exist");
        }
        else
        {
            u.Orders = customer.Orders;
            u.SelectedStore = customer.SelectedStore;
            _ctx.SaveChanges();
        }
    }
    public void Update()
    {
        _ctx.SaveChanges();
    }
    public void UpdateStore(Store store)
    {
        var s =  _ctx.Stores.ToList().FirstOrDefault(x => x.EntityId==store.EntityId);
        if(s==null)
        {
            System.Console.WriteLine("Store does not exist");
        }
        else
        {
            s.Orders = store.Orders;
            _ctx.SaveChanges();
        }
    }
    public Order GetPrevOrder()
    {
        return _ctx.Orders.Include(o=>o.Pizzas).ThenInclude(p=>p.Crust)
                          .Include(o=>o.Pizzas).ThenInclude(p=>p.Size)
                          .Include(o=>o.Pizzas).ThenInclude(p=>p.Toppings)
                          .ToList().Last();
    }
    
    public void Pizza()
        {
            if(ReadPizzas().Count()==0)
            {
                
                Crust c=ReadCrust().FirstOrDefault(x => x.Name.Contains("Regular"));
                Size s=ReadSize().FirstOrDefault(x => x.Name.Contains("Medium"));
                Toppings t =ReadToppings().FirstOrDefault(x => x.Name.Contains("Pepperoni"));
                Toppings t1 =ReadToppings().FirstOrDefault(x => x.Name.Contains("Italian Sausage"));
                Toppings t2 =ReadToppings().FirstOrDefault(x => x.Name.Contains("Beef Sausage"));
                Toppings t3 =ReadToppings().FirstOrDefault(x => x.Name.Contains("Mozerella Cheese"));
                List<Toppings> tps = new List<Toppings>{t,t1,t2,t3};
                Pizza meatpizza = new Pizza(c,s,tps);
                meatpizza.Name = "Three Meat Pizza";
                Save(meatpizza);

                
                c=ReadCrust().FirstOrDefault(x => x.Name.Contains("Regular"));
                s=ReadSize().FirstOrDefault(x => x.Name.Contains("Medium"));
                Toppings t4 =ReadToppings().FirstOrDefault(x => x.Name.Contains("Mozerella Cheese"));
                Toppings t5 =ReadToppings().FirstOrDefault(x => x.Name.Contains("Parmesean Cheese"));
                Toppings t6 =ReadToppings().FirstOrDefault(x => x.Name.Contains("Mozerella Cheese"));
                List<Toppings> top = new List<Toppings>{t4,t5,t6};
                Pizza cheesepizza = new Pizza(c,s,top);
                cheesepizza.Name = "Three Cheese Pizza";
                Save(cheesepizza);

                c=ReadCrust().FirstOrDefault(x => x.Name.Contains("Regular"));
                s=ReadSize().FirstOrDefault(x => x.Name.Contains("Medium"));
                Toppings t7 =ReadToppings().FirstOrDefault(x => x.Name.Contains("Mozerella Cheese"));
                Toppings t8 =ReadToppings().FirstOrDefault(x => x.Name.Contains("Olives"));
                Toppings t9 =ReadToppings().FirstOrDefault(x => x.Name.Contains("Peppers"));
                Toppings t10 =ReadToppings().FirstOrDefault(x => x.Name.Contains("Onions"));
                List<Toppings> tns = new List<Toppings>{t7,t8,t9,t10};
                Pizza supremepizza = new Pizza(c,s,tns);
                supremepizza.Name = "Supreme Pizza";
                Save(supremepizza);
            }
            else
            {
                Console.WriteLine(" Welcome to one our woncerful PizzaCity locations!");
            }
        }
}
}
  
