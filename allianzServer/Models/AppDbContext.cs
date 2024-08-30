using Microsoft.EntityFrameworkCore;


namespace allianzServer.Models
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions options) : base(options) { }


        public DbSet<MusteriTable>? MusteriTable { get; set; }
        public DbSet<PoliceTable>? PoliceTable { get; set; }
        public DbSet<OdemeTable>? OdemeTable { get; set; }
        public DbSet<TeminatTable>? TeminatTable { get; set; }



    }
}