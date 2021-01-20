using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PizzaCity.Domain.Models;
using PizzaCity.Domain.Abstracts;
using PizzaCity.Storage;
using PizzaCity.Client.Models;
using System.Collections.Generic;

namespace PizzaCity.Client.Controllers
{
  public class OrderController : Controller
  {
    private readonly PizzaCityRepo _repo;
    public OrderController(PizzaCityRepo repository)
    {
      _repo = repository;
    }

    [HttpGet]
    [Route("action]")]
    public IActionResult ReviewOrder(OrderViewModel model)
    {
      var order = _repo.GetPrevOrder();
      model.PizzaView = new List<PizzaViewModel>();

      foreach (var pizza in order.Pizzas )
      {
        var p = new PizzaViewModel() 
        {
          Size = pizza.Size.Name,
          Crust = pizza.Crust.Name,
          ToppingNames = new List<string>(),
          Price = pizza.Price
        };
        
        foreach (var entry in pizza.Toppings)
        {
          p.ToppingNames.Add(entry.Name);
        };

        model.PizzaView.Add(p);
      
      };

      return View("ReviewOrder",model);       
    }

    [HttpGet]
    [Route("[action]")]
    public IActionResult CompleteOrder(OrderViewModel model)
    {
      model.CustomerName = TempData.Peek("CustomerName") as string;
      return View("PassOrder", model);
    }

    [HttpGet]
    [Route("action")]
    public IActionResult OrderPizza()
    {
      var o = new OrderViewModel()
      {
        PizzaNames = _repo.GetPizza(),
        Pizzas = _repo.ReadPizza().ToList(),
        Toppings = _repo.ReadToppings().ToList()

      };

      return View("OrderPizza", o);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Post(OrderViewModel model)
    {
      if (ModelState.IsValid)
      {
        var order = new Order()
        {
          OrderModified = DateTime.Now,
          Store = _repo.ReadStores().FirstOrDefault(s => s.Name == model.Store)
        };

        _repo.Save(order);

        return View("OrderPlaced",model);
      }

      return View("HOME", model);

    }

    [Route("[action]")]
    [HttpPost]
    public IActionResult AddPizza(OrderViewModel model)
    {
      if (ModelState.IsValid)
      {
        var order = _repo.GetPrevOrder();
        var builtpizza = _repo.ReadPizzas().First(s => s.EntityId == long.Parse(model.pizza));
        PizzaModel pizza = new Pizza();

        pizza.Name = builtpizza.Name;
        pizza.Crust = builtpizza.Crust;
        pizza.Size = builtpizza.Size;
        pizza.Toppings = builtpizza.Toppings;
        pizza.SetPrice();

        if (order.Pizzas==null)
        {
          order.Pizzas = new List<PizzaModel>(); 
        }

        order.Pizzas.Add(pizza);
        order.CalculatePrice();
        model.Price = order.Price;
        _repo.Update();
        model.PizzaView = new List<PizzaViewModel>();

        foreach (var item in order.Pizzas)
        {
          var n = new PizzaViewModel()
          {
            Name = item.Name,
            Crust = item.Crust.Name,
            Size = item.Size.Name,
            ToppingNames = new List<string>(),
            Price = item.Price

          };

          foreach (var top in item.Toppings)
          {
            n.ToppingNames.Add(top.Name); 
          };

          model.PizzaView.Add(n);   
        };

          return View("OrderPlaced", model);


      }

      return View("HOME", model);
    }
  }
}