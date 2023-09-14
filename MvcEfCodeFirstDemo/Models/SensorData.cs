using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class SensorData
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        [Required]
        public Guid SensorId { get; set; }
        public double Value { get; set; }

        [Required]
        public DateTime Timestamp { get; set; } = DateTime.Now;
    }
}
