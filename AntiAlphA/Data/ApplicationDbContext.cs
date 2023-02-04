using AntiAlphA.Model;
using System.Data.Entity;

namespace AntiAlphA.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("AntiAlphaDB")
        {
        }
        
        public DbSet<RequestF> RequestFs { get; set; }
        public DbSet<RequestU> RequestUs { get; set; }
        public DbSet<ResponseF> ResponseFs { get; set; }
        public DbSet<ResponseU> ResponseUs { get; set; }
        public DbSet<MaxSize> MaxSizes { get; set; }


    }
}