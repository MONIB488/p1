using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using PizzaCity.Domain.Abstracts;
using PizzaCity.Domain.Models;

namespace PizzaCity.Client.Models
{
    public class PizzaViewModel
    { 

        public List<Crust> Crusts {get;set;}
        public List<Size> Sizes { get; set; }
        public List<Toppings> Toppings {get;set;}

        public List<string> PizzaNames { get; set; }
        
        public string pizza {get;set;}
        public string Name {get; set;}
        public string Crust { get; set; } 
        public string Size { get; set; }
        
        public List<string> ToppingNames { get; set;}
        public List<SelectListItem> SelectToppings{ get; set; }
        public double Price{get;set;}

        


    }
}