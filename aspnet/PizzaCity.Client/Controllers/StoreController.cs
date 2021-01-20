using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PizzaCity.Client.Models;
using PizzaCity.Storage;

namespace PizzaCity.Client.Controllers
{
    
    [Route("[controller]")]
    public class StoreController : Controller
    {
        
        private readonly PizzaCityRepo _ctx;

        public StoreController(PizzaCityRepo context)
        {
            _ctx = context;
        }
        [Route("[action]")]
        [HttpGet]
        public IActionResult StoreList()
        {
            var stores = new StoreViewModel();
            
            ViewBag.Stores = stores.Stores; 
            ViewData["Stores"]= stores.Stores; 
            
            
            TempData["Stores"]= stores.Stores;
            return View("Store",new StoreViewModel());
        }
        [Route("[action]")]
        [HttpGet]
        public IActionResult SelectStore()
        {
            StoreViewModel model = new StoreViewModel();
            model.Stores = _ctx.GetStores();

            return View("SelectStore",model);
        }
        [Route("[action]")]
        [HttpPost]
        public IActionResult PostStore(StoreViewModel model)
        {
            TempData["ChosenStore"] = model.ChosenStore;
            return View("StoreHome",model);
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult StoreHistory()
        {
            StoreViewModel model = new StoreViewModel();
            model.ChosenStore = TempData.Peek("ChosenStore") as string;
            model.StoreOrderHistory = _ctx.StoreOrders(model.ChosenStore).ToList();
            double total = 0;
            foreach (var item in model.StoreOrderHistory)
            {
                total = total+item.Price;        
            }

            model.Total=total;
            
            return View("StoreOrderHistory",model);
        }
        
    }
}