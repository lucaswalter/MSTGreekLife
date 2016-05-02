using MSTGreekLife.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MSTGreekLife.DAL
{
    public class GreekLifeContext : DbContext
    {
        // Name Of Connection String: GreekLifeDbContext
        public GreekLifeContext() : base("DefaultConnection")
        {
        }

        public DbSet<SchoolModel> Schools { get; set; }
        public DbSet<GreekHouseModel> GreekHouses { get; set; }
        public DbSet<StudentModel> Students { get; set; }
        public DbSet<GuestModel> Guests { get; set; }
        public DbSet<PartyModel> Parties { get; set; }
        public DbSet<BlacklistModel> Blacklistings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}