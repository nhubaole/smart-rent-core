using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace RoomService.Model
{
    [Table("Room")]
    public class Room
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoomId { get; set; } // Primary Key

        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public string RoomType { get; set; }
        [Required]
        public int Capacity { get; set; }
        public string Gender { get; set; }
        [Required]
        public double Area { get; set; }
        [Required]
        public int Price { get; set; }

        public int Deposit { get; set; }
        public int ElectricityCost { get; set; }
        public int WaterCost { get; set; }
        public int InternetCost { get; set; }
        public double SumRating { get; set; }
        public bool HasParking { get; set; }
        public int? ParkingFee { get; set; }
        public string Location { get; set; }
        public string? Utilities { get; set; }
        public string CreatedBy { get; set; }
        public bool IsRented { get; set; }
        //  public string Status { get; set; }
        public string? Image { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string? DeleteTime { get; set; }
    }
}
