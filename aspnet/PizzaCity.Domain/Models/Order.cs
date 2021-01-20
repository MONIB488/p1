using System;
using System.Collections.Generic;
using PizzaCity.Domain.Abstracts;

namespace PizzaCity.Domain.Models
{
  public class Order : AModel
  {
    public Store Store { get; set; }
    public Customer Customer { get; set; }
    public ICollection<PizzaModel> Pizzas {get; set;}
    public DateTime OrderModified { get; set; }
    public double Price{get; set;}
    public Order()
    {
      OrderModified = DateTime.Now;
    }
    public Order(List<PizzaModel> m)
        {
            Pizzas = m;
            OrderModified = DateTime.Now;
            CalculatePrice();
        }
        public void CalculatePrice()
        {
            double total=0;
            foreach (var item in Pizzas)
            {
                total += item.Price;
            }
            Price = total;
        }

        public override string ToString()
        {
            var sb = new System.Text.StringBuilder();

            sb.Append(String.Format(" {1,-20} {2,-20}\n\n","Customer name","Total Price"));
            sb.Append(String.Format("{0,-20} {2,-20}\n",Customer.Name,"$"+Price));
            sb.Append(String.Format("{1,-25} {2,-20}\n\n","Pizza Ordered","Price"));
            foreach(var p in Pizzas)
            {
                sb.Append(String.Format("{1,-15} {2,-15}\n",p.Name,p.Price));
            } 
            return sb.ToString();
        }


    }
}
  
