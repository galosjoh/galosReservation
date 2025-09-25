using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace RestReservation.Models
{
    [BsonIgnoreExtraElements]
    public class Reservation
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        
        [BsonRepresentation(BsonType.ObjectId)]
        public string? RestaurantId { get; set; }

        public string? RestaurantName { get; set; }
        
        [Required(ErrorMessage = "The date and time is required to make this reservation")]
        [Display(Name = "Date")]
        public DateTime date { get; set; }
    }
}