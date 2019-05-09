using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using BestRestaurants.Models;

namespace BestRestaurants.Controllers
{
    public class CuisinesController : Controller
    {
        [HttpGet("/cuisines")]
        public ActionResult Index()
        {
            List<Cuisine> allCuisines = Cuisine.GetAll();
            return View(allCuisines);
        }

        [HttpGet("/cuisines/new")]
        public ActionResult New()
        {
            return View();
        }

        [HttpGet("/cuisines/{id}")]
        public ActionResult Show(int id)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Cuisine selectedCuisine = Cuisine.Find(id);
            List<Restaurant> cuisineRestaurants = selectedCuisine.GetRestaurants();
            model.Add("cuisine", selectedCuisine);
            model.Add("restaurants", cuisineRestaurants);
            return View(model);
        }

        [HttpPost("/cuisines/{cuisineId}/restaurants")]
        public ActionResult Create(int cuisineId, string restaurantName, string restaurantDescription)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Cuisine foundCuisine = Cuisine.Find(cuisineId);
            Restaurant newRestaurant = new Restaurant(restaurantName, restaurantDescription, cuisineId);
            newRestaurant.Save();
            List<Restaurant> cuisineRestaurants = foundCuisine.GetRestaurants();
            model.Add("restaurants", cuisineRestaurants);
            model.Add("cuisine", foundCuisine);
            return View("Show", model);
        }
    }
}
