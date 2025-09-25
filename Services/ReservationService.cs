using MongoDB.Driver;
using galosReservation.Models;
using System.Collections.Generic;
using System.Linq;

namespace galosReservation.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IMongoCollection<Reservation> _reservationsCollection;
        private readonly IMongoCollection<Restaurant> _restaurantsCollection;

        public ReservationService(IMongoDatabase database)
        {
            _reservationsCollection = database.GetCollection<Reservation>("reservations");
            _restaurantsCollection = database.GetCollection<Restaurant>("restaurants");
        }

        public IEnumerable<Reservation> GetAllReservations()
        {
            return _reservationsCollection.Find(_ => true).ToList();
        }

        public Reservation? GetReservationById(MongoDB.Bson.ObjectId id)
        {
            return _reservationsCollection.Find(reservation => reservation.Id == id.ToString()).FirstOrDefault();
        }

        public void AddReservation(Reservation newReservation)
        {
            var bookedRestaurant = _restaurantsCollection.Find(r => r.Id == newReservation.RestaurantId).FirstOrDefault();

            if (bookedRestaurant == null)
            {
                throw new ArgumentException("The restaurant to be reserved cannot be found.");
            }

            newReservation.RestaurantName = bookedRestaurant.name;
            _reservationsCollection.InsertOne(newReservation);
        }
        public void DeleteReservation(Reservation reservationToDelete)
        {
            _reservationsCollection.DeleteOne(r => r.Id == reservationToDelete.Id);
        }

        public void EditReservation(Reservation updatedReservation)
        {
            var filter = Builders<Reservation>.Filter.Eq(r => r.Id, updatedReservation.Id);
            var update = Builders<Reservation>.Update.Set(r => r.date, updatedReservation.date);

            var result = _reservationsCollection.UpdateOne(filter, update);

            if (result.MatchedCount == 0)
            {
                throw new ArgumentException("Reservation to be updated cannot be found");
            }
        }

        public void DeleteReservation(string id)
        {
            var result = _reservationsCollection.DeleteOne(r => r.Id == id);

            if (result.DeletedCount == 0)
            {
                throw new ArgumentException("The reservation to delete cannot be found.");
            }
        }
    }
}   