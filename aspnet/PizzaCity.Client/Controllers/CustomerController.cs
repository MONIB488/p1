using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PizzaCity.Storage;
using PizzaCity.Client.Models;

namespace PizzaCity.Client.Controllers
{
  [Route("[controller]")]
  public class CustomerController : Controller
  {
    private readonly PizzaCityRepo _repo;
    public CustomerController(PizzaCityRepo repository)
    {
      _repo = repository;
    }
    [Route("")]
    [Route("[action]")]

    [HttpGet]
    public IActionResult Home()
    {
      var customer = new CustomerViewModel()
      {
        Customers = _repo.ReadCustomers().ToList(),
        StoreView = new StoreViewModel()
      };

      customer.StoreView.Stores = _repo.GetStores().ToList();

      customer.Order = new OrderViewModel()
      {
        //Store = _repo.GetStores().ToList(),
        Pizzas = _repo.ReadPizza().ToList(),
        PizzaNames = _repo.GetPizza().ToList(),
        Toppings = _repo.ReadToppings().ToList()
      };

      return View("HOME", customer);
    }

    [Route("[action]")]
    [HttpGet]
    public IActionResult CustomerOrderHistory()
    {
      var customer = new CustomerViewModel()
      {
        Name = TempData.Peek("CustomerName") as string
      };
      customer.Customer = _repo.ReadCustomers().FirstOrDefault(c => c.Name==customer.Name);
      if(customer.Customer == null)
      {
        Console.WriteLine("Customer Null");
      }
      return View("CustomerOrderHistory",customer);
    }
  }
}