using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.Extensions.Configuration;
using PizzaCity.Storing;

namespace PizzaCity.Client.Models
{
  public class OrderViewModel
  {
    public List<string> Stores { get; set; }

    [Required]
    public string Store { get; set; }
  }
}