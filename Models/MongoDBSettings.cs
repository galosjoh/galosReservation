namespace galosReservation.Models
{
    public class MongoDBSettings
    {
        public string AtlasURI { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string RestaurantsCollectionName { get; set; } = null!;
        public string ReservationsCollectionName { get; set; } = null!;
    }
}
