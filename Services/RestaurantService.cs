using MongoDB.Driver;
using galosReservation.Models;
using System.Collections.Generic;
using System.Linq;

namespace galosReservation.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IMongoCollection<Restaurant> _restaurantsCollection;

        public RestaurantService(IMongoDatabase database)
        {
            _restaurantsCollection = database.GetCollection<Restaurant>("restaurants");
        }

        public IEnumerable<Restaurant> GetAllRestaurants()
        {
            return _restaurantsCollection.Find(_ => true).ToList();
        }

        public Restaurant? GetRestaurantById(string id)
        {
            return _restaurantsCollection.Find(restaurant => restaurant.Id == id).FirstOrDefault();
        }

        public void AddRestaurant(Restaurant restaurant)
        {
            _restaurantsCollection.InsertOne(restaurant);
        }

        public void EditRestaurant(Restaurant restaurant)
        {
            var filter = Builders<Restaurant>.Filter.Eq(r => r.Id, restaurant.Id);
            var update = Builders<Restaurant>.Update
                .Set(r => r.name, restaurant.name)
                .Set(r => r.cuisine, restaurant.cuisine)
                .Set(r => r.borough, restaurant.borough)
                .Set(r => r.Address, restaurant.Address);

            var result = _restaurantsCollection.UpdateOne(filter, update);

            if (result.MatchedCount == 0)
            {
                throw new ArgumentException("The restaurant to update cannot be found. ");
            }
        }

        public void DeleteRestaurant(string id)
        {
            var result = _restaurantsCollection.DeleteOne(r => r.Id == id);

            if (result.DeletedCount == 0)
            {
                throw new ArgumentException("The restaurant to delete cannot be found.");
            }
        }
    }
}