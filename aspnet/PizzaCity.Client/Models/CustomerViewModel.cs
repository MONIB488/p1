using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PizzaCity.Domain.Models;
using PizzaCity.Storing;
using PizzaCity.Client.Models;

namespace PizzaCity.Client.Controllers
{
  public class OrderController : Controller
  {
    private readonly PizzaCityContext _ctx;
    public OrderController(PizzaCityContext context)
    {
      _ctx = context;
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Post(OrderViewModel model)
    {
      if (ModelState.IsValid)
      {
        var order = new Order()
        {
          DateModified = DateTime.Now,
          Store = _ctx.Stores.FirstOrDefault(s => s.Name == model.Store)
        };

        _ctx.Orders.Add(order);
        _ctx.SaveChanges();

        return View("OrderPlaced");
      }

      return View("home", model);
    }
  }
}