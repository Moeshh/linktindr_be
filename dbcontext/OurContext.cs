using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbcontext {
    public class OurContext : DbContext {
        public OurContext(DbContextOptions options) : base(options) { }
        public DbSet<Medewerker> medewerkers { get; set; }
        public DbSet<TalentManager> talentmanagers { get; set; }
    }
}
