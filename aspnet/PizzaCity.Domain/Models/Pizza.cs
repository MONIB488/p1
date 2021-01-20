using System.Collections.Generic;
using PizzaCity.Domain.Abstracts;

namespace PizzaCity.Domain.Models
{
    public class Pizza : PizzaModel
  {    
    // public Crust Crust { get; set; }
    // public Size Size { get; set; }
    // public ICollection<Toppings> Toppings { get; set; }

    public Pizza()
    {
  
    }
    public Pizza(Crust c, Size s,List<Toppings> t)
    {
      Crust = c;
      Size = s;
      Toppings = t;
      SetPrice();
    }
    protected override void SetName(string n)
    {
      this.Name = n;
    }

    public override void SetPrice()
    {
      double total=0;
      foreach (var item in Toppings)
      {
          total += item.Price;
      }
      total += Size.Price;
      total += Crust.Price;
      Price = total+8;
    }
    protected override void AddCrust(Crust c) 
    { 
      Crust = c;
    }
    protected override void AddSize(Size s) 
    { 
      Size=s;
    }
    protected override void AddToppings(List<Toppings> t) 
    { 
      Toppings = t;
    }
  }
}