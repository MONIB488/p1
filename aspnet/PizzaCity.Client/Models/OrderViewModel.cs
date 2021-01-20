using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PizzaCity.Domain.Models;
using PizzaCity.Domain.Abstracts;
using System;


namespace PizzaCity.Client.Models
{
  public class OrderViewModel
  {
    public StoreViewModel StoreView { get; set; }
    public List<Pizza> Pizzas{get; set;}
    public List<PizzaViewModel> PizzaView{get; set;}


    public List<string> PizzaNames{get;set;}
    public List<Crust> Crusts{get; set;}
    public List<Size> Sizes{get; set;}
    public List<Toppings> Toppings{get; set;}
    public double Price {get; set;}

    [Required]
    public string Store { get; set; }
    public string CustomerName{get;set;}
    public string pizza{get;set;}
  } 
}