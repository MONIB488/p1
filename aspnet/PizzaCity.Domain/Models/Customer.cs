using System.Collections.Generic;
using PizzaCity.Domain.Abstracts;

namespace PizzaCity.Domain.Models
{
    public class Customer : AModel
    {
        public ICollection<Order> Orders { get; set; }
        public string Name { get; set; }
        public Store SelectedStore { get; set; }

        public Customer()
        {}

        public override string ToString()
        {
            if(Name != null)
            {
                return Name;
            }
            return "NameDoesNotExist"; 
        }
    
    }
}