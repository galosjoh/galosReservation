using galosReservation.Models;
using System.Collections.Generic;

namespace galosReservation.Services
{
    public interface IRestaurantService
    {
        IEnumerable<Restaurant> GetAllRestaurants();
        Restaurant? GetRestaurantById(string id);
        void AddRestaurant(Restaurant newRestaurant);
        void EditRestaurant(Restaurant updatedRestaurant);
        void DeleteRestaurant(string id);
    }
}