using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class SensorData
    {
        [Key]
        public int Id { get; set; }        

        [Required]
        public int SensorId { get; set; }
        public double Value { get; set; }

        [Required]
        public DateTime Timestamp { get; set; } = DateTime.Now;
    }
}
