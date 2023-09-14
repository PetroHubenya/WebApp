using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Sensor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public TypeOfSensor Type { get; set; }

        [Required]
        public int BoxId { get; set; }
        public ICollection<SensorData>? SensorsData { get; set; }
    }
}
