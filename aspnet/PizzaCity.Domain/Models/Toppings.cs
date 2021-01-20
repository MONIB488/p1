using System.Collections.Generic;
using PizzaCity.Domain.Abstracts;

namespace PizzaCity.Domain.Models
{
  public class Toppings : PizzaObject
  {
    public ICollection<PizzaModel> Pizzas {get;set;}
    
    
  }
}