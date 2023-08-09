using Microsoft.EntityFrameworkCore;

namespace IOTBackend.Models
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options):base(options)
        {

        }

        public DbSet<Light> Lights { get; set; }
    }
}
