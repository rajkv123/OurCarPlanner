using OurCarPlanner.CustomAttributes;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace OurCarPlanner.Models
{
    public class Car
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("CarId")]
        [Required]
        public int CarId { get; set; }

        [BsonElement("Brand")]
        [Required]
        public string Brand { get; set; }

        [BsonElement("Model")]
        [Required]
        public string Model { get; set; }

        [BsonElement("Year")]
        [Required]
        [YearRange]
        public int Year { get; set; }


        [BsonElement("Color")]
        [Required]
        public string Color { get; set; }

        [BsonElement("No_Of_Seat")]
        [Required]
        public int No_Of_Seat { get; set; }

        [BsonElement("Fuel_Type")]
        [Required]
        public string Fuel_Type { get; set; }

        [BsonElement("Owner_Name")]
        [Required]
        public string Owner_Name { get; set; }

        [BsonElement("Registration_Number")]
        [Required]
        public string Registration_Number { get; set; }

        [BsonElement("UserId")]
        [Required]
        public int UserId { get; set; }

        [BsonElement("Price")]
        [Display(Name = "Price($)")]
        [DisplayFormat(DataFormatString = "{0:#,0}")]
        public decimal Price { get; set; }

        [BsonElement("ImageUrl")]
        [Display(Name = "Photo")]
        [DataType(DataType.ImageUrl)]
        [Required]
        public string ImageUrl { get; set; }
        //public byte[] ImageUrl { get; set; }
    }

}
