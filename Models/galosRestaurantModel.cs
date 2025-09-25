using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace RestReservation.Models
{
    public class ContactInfo
    {
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Website { get; set; }
    }

    public class OpeningHours
    {
        public string Day { get; set; } = string.Empty;
        public string OpenTime { get; set; } = string.Empty;
        public string CloseTime { get; set; } = string.Empty;
    }

    [BsonIgnoreExtraElements]
    public class Restaurant
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [Required(ErrorMessage = "You must provide a name")]
        [Display(Name = "Name")]
        public string name { get; set; } = string.Empty;

        [Required(ErrorMessage = "You must add a cuisine type")]
        [Display(Name = "Cuisine")]
        public string cuisine { get; set; } = string.Empty;

        [Required(ErrorMessage = "You must add the borough of the restaurant")]
        [Display(Name = "Borough")]
        public string borough { get; set; } = string.Empty;

        [Required(ErrorMessage = "You must add the address of the restaurant")]
        [Display(Name = "Address")]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "You must add a valid contact info")]
        [Display(Name = "Contact Info")]
        public ContactInfo ContactInfo { get; set; } = new ContactInfo();
        
        [Display(Name = "Opening Hours")]
        public List<OpeningHours> OpeningHours { get; set; } = new List<OpeningHours>();
    }
}