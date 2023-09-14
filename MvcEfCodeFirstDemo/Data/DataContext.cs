using Models;
using Microsoft.EntityFrameworkCore;

namespace MvcEfCodeFirstDemo.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Models.Box> Boxes {  get; set; }
        
        public DbSet<Sensor> Sensors { get; set; }

        public DbSet<SensorData> SensorsData { get; set; }
    }
}
