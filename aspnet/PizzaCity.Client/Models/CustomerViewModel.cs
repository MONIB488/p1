using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PizzaCity.Domain.Models;
using Microsoft.Extensions.Configuration;

namespace PizzaCity.Client.Models
{
  public class CustomerViewModel
  {
    public string Name { get; set; }
    public OrderViewModel Order { get; set; }
    public Customer Customer {get; set;}
    public List<Customer> Customers {get; set;}
    public StoreViewModel StoreView {get; set;}
    public string store {get; set;}
    public PizzaViewModel PizzaView{get; set;}

    public CustomerViewModel()
    {
      Name = "Monica";
      Order = new OrderViewModel();
    }
  }
}