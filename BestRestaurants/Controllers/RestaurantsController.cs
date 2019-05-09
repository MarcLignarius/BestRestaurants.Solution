using Microsoft.AspNetCore.Mvc;
using BestRestaurants.Models;
using System.Collections.Generic;

namespace BestRestaurants.Controllers
{

    public class RestaurantsController : Controller
    {
        [HttpGet("/cuisines/{cuisineId}/restaurants/new")]
        public ActionResult New(int cuisineId)
        {
            Cuisine cuisine = Cuisine.Find(cuisineId);
            return View(cuisine);
        }
    }
}
