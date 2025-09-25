
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using galosReservation.Models;

namespace galosReservation.Services
{
    public class MongoDBService
    {
        private readonly IMongoCollection<Restaurant> _restaurantsCollection;
        private readonly IMongoCollection<Reservation> _reservationsCollection;

        public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings)
        {
            var mongoClient = new MongoClient(mongoDBSettings.Value.AtlasURI);

            var mongoDatabase = mongoClient.GetDatabase(mongoDBSettings.Value.DatabaseName);

            _restaurantsCollection = mongoDatabase.GetCollection<Restaurant>(
                mongoDBSettings.Value.RestaurantsCollectionName);

            _reservationsCollection = mongoDatabase.GetCollection<Reservation>(
                mongoDBSettings.Value.ReservationsCollectionName);
        }
    }
}
