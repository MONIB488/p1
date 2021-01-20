using System.Collections.Generic;

namespace PizzaCity.Domain.Abstracts
{
  public abstract class PizzaObject : AModel
  {
    public string Name { get; set; }
    public double Price { get; set; }
  }
}