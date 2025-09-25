using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using galosReservation.Models;
using galosReservation.Services;
using galosReservation.ViewModels;

namespace galosReservation.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly IRestaurantService _RestaurantService;

        public RestaurantController(IRestaurantService RestaurantService)
        {
            _RestaurantService = RestaurantService;
        }

        public IActionResult Index()
        {
            RestaurantListViewModel viewModel = new()
            {
                Restaurants = _RestaurantService.GetAllRestaurants(),
            };
            return View(viewModel);
        }
    }
}