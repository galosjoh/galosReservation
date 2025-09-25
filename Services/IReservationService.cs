using MongoDB.Bson;
using galosReservation.Models;

namespace galosReservation.Services
{
    public interface IReservationService
    {
        IEnumerable<Reservation> GetAllReservations();
        Reservation? GetReservationById(ObjectId id);
        void AddReservation(Reservation newReservation);
        void EditReservation(Reservation updatedReservation);
        void DeleteReservation(Reservation reservationToDelete);
    }
}