using System.Collections.Generic;
using PizzaCity.Domain.Models;

namespace PizzaCity.Domain.Abstracts
{
  public class PizzaModel : PizzaObject
  {
    public Crust Crust { get; set; }
    public Size Size { get; set; }
    public ICollection<Toppings> Toppings { get; set; }
    public ICollection<Order> Orders { get; set; }

    public virtual void SetPrice()
    { 
    }
    protected virtual void SetName(string str)
    {

    }
    protected virtual void AddCrust(Crust c) { }
    protected virtual void AddSize(Size s) { }
    protected virtual void AddToppings(List<Toppings> t) { }
  }
}