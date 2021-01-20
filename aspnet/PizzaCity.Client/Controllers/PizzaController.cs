using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace PizzaCity.Client.Controllers
{
    public class PizzaController : Controller
    {
        [HttpGet]
        public IEnumerable<string> GetPizzaList()
        {
            return new List<string>();
        }
    }
}