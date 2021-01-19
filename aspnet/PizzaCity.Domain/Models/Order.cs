using System;
using PizzaCity.Domain.Abstracts;

namespace PizzaCity.Domain.Models
{
  public class Order : AModel
  {
    public Store Store { get; set; }
    public long StoreEntityId { get; set; }
    public DateTime DateModified { get; set; }
  }
}