using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace dbcontext {
    public class OurContext : DbContext {
        public OurContext(DbContextOptions options) : base(options) { }
        public DbSet<Medewerker> medewerker { get; set; }
        public DbSet<TalentManager> talentmanager { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseMySQL("server=yc2302sql.mysql.database.azure.com;database=yc2302;user=yc2302;password=Water123");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Medewerker>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Talentmanager_id).IsRequired();
            });

            modelBuilder.Entity<TalentManager>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Email).IsRequired();
            });
        }
    }

}
