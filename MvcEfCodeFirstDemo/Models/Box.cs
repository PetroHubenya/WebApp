using Models;
using System.ComponentModel.DataAnnotations;

namespace MvcEfCodeFirstDemo.Models
{
    public class Box
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<Sensor>? Sensors { get; set; }

    }
}
