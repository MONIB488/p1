using System;
using System.Collections.Generic;
using PizzaCity.Domain.Abstracts;

namespace PizzaCity.Domain.Models
{
  public class Store : AModel
  {
    public string Name { get; set; }
    public ICollection<Order> Orders { get; set; }
    public Store()
        {
            Name = "Store Name";
          
            Orders = new List<Order>();
            
        }
        public void CreateOrder(List<PizzaModel> Pizzas, Customer customer)
        {
            Order o = new Order(Pizzas);
            o.Store = this;
            o.CalculatePrice();
            o.Customer = customer;
            Console.WriteLine("Create Order");

            Orders.Add(o);
           
        }
  }
}
