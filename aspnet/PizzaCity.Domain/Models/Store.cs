using System.Collections.Generic;
using PizzaCity.Domain.Abstracts;

namespace PizzaCity.Domain.Models
{
  public class Store : AModel
  {
    public string Name { get; set; }
    public List<Order> Orders { get; set; }
  }
}
