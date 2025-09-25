using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using galosReservation.Models;
using galosReservation.Services;
using galosReservation.ViewModels;

namespace galosReservation.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IReservationService _ReservationService;
        private readonly IRestaurantService _RestaurantService;

        public ReservationController(IReservationService ReservationService, IRestaurantService RestaurantService)
        {
            _ReservationService = ReservationService;
            _RestaurantService = RestaurantService;
        }

        public IActionResult Index()
        {
            ReservationViewListModel viewModel = new()
            {
                Reservations = _ReservationService.GetAllReservations()
            };
            return View(viewModel);
        }
    }
}