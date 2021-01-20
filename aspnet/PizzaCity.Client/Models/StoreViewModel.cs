using System.Collections.Generic;
using PizzaCity.Domain.Models;

namespace PizzaCity.Client.Models
{
    public class StoreViewModel 
    {
        public List<string> Stores { get; set; } 
        public string ChosenStore { get; set;}
        public List<Order> StoreOrderHistory {get;set;}
        public List<Store> StoreEntry {get; set;}
        public double Total { get; set; }
        public StoreViewModel()
        {
        }
    }
}