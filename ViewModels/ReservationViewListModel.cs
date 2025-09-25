using galosReservation.Models;

namespace galosReservation.ViewModels
{
    public class ReservationViewListModel
    {
        public IEnumerable<Reservation>? Reservations { get; set; }
    }
}