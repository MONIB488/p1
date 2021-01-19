using System.Collections.Generic;
using System.Linq;
using PizzaCity.Domain.Abstracts;

namespace PizzaCity.Storage
{
  public class PizzaCityRepo
  {
    private PizzaCityContext _ctx;

    public PizzaCityRepo(PizzaCityContext context)
    {
      _ctx = context;
    }

    public List<string> GetStores()
    {
      return _ctx.Stores.Select(s => s.Name).ToList();
    }