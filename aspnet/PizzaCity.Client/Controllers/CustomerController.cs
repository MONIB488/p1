using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PizzaCity.Storage;
using PizzaCity.Client.Models;

namespace PizzaCity.Client.Controllers
{
  public class CustomerController : Controller
  {
    private readonly PizzaCityRepo _ctx;
    public CustomerController(PizzaCityRepo context)
    {
      _ctx = context;
    }

    [HttpGet]
    public IActionResult Home()
    {
      var customer = new CustomerViewModel();

      customer.Order = new OrderViewModel()
      {
        Stores = _ctx.GetStores()
      };

      return View("home", customer);
    }
  }
}