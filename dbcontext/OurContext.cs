using dbcontext.Classes;
using Microsoft.EntityFrameworkCore;

namespace dbcontext
{
    public class OurContext : DbContext
    {
        public OurContext(DbContextOptions options) : base(options) { }
        public DbSet<Medewerker> Medewerker { get; set; }
        public DbSet<Opdrachtgever> Opdrachtgever { get; set; }
        public DbSet<Plaatsing> Plaatsing { get; set; }
        public DbSet<Sollicitatie> Sollicitatie { get; set; }
        public DbSet<TalentManager> TalentManager { get; set; }
        public DbSet<Vacature> Vacatures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            // Medewerker

            modelBuilder.Entity<Medewerker>()
                .Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnType("VARCHAR(255)")
                .IsRequired();

            modelBuilder.Entity<Medewerker>()
                .Property(e => e.DateOfBirth)
                .HasColumnType("Datetime(6)")
                .IsRequired();

            modelBuilder.Entity<Medewerker>()
                .Property(e => e.PostCode)
                .HasMaxLength(6)
                .HasColumnType("VARCHAR(6)")
                .IsRequired();

            modelBuilder.Entity<Medewerker>()
                .Property(e => e.HouseNumber)
                .HasMaxLength(255)
                .HasColumnType("VARCHAR(255)")
                .IsRequired();

            modelBuilder.Entity<Medewerker>()
                .Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnType("VARCHAR(255)")
                .IsRequired();

            modelBuilder.Entity<Medewerker>()
                .Property(e => e.Telephone)
                .HasMaxLength(20)
                .HasColumnType("VARCHAR(20)")
                .IsRequired();

            modelBuilder.Entity<Medewerker>()
                .Property(e => e.Radius)
                .HasMaxLength(3)
                .HasColumnType("INT(3)")
                .IsRequired();

            modelBuilder.Entity<Medewerker>()
                .Property(e => e.Uitstroomrichting)
                .IsRequired()
                .HasConversion(
                    v => v.ToString(),
                    v => Enum.Parse<Specialization>(v));

            modelBuilder.Entity<Medewerker>()
                .Property(e => e.Photo)
                .HasMaxLength(255)
                .HasColumnType("VARCHAR(255)");

            modelBuilder.Entity<Medewerker>()
                .Property(e => e.ProfileText)
                .HasColumnType("TEXT");

            modelBuilder.Entity<Medewerker>()
                .Property(e => e.Token)
                .HasMaxLength(100)
                .HasColumnType("VARCHAR(100)");

            modelBuilder.Entity<Medewerker>()
                .HasOne(m => m.TalentManager);



            // Talentmanager

            modelBuilder.Entity<TalentManager>()
                .Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnType("VARCHAR(255)")
                .IsRequired();

            modelBuilder.Entity<TalentManager>()
                .Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnType("VARCHAR(255)")
                .IsRequired();

            modelBuilder.Entity<TalentManager>()
                .Property(e => e.Telephone)
                .HasMaxLength(20)
                .HasColumnType("VARCHAR(20)")
                .IsRequired();

            modelBuilder.Entity<Medewerker>()
                .Property(e => e.Token)
                .HasMaxLength(100)
                .HasColumnType("VARCHAR(100)");

            modelBuilder.Entity<TalentManager>()
                .HasMany(t => t.Medewerkers);

            // Opdrachtgever

            modelBuilder.Entity<Opdrachtgever>()
                .Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnType("VARCHAR(255)")
                .IsRequired();

            modelBuilder.Entity<Opdrachtgever>()
                .Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnType("VARCHAR(255)")
                .IsRequired();

            modelBuilder.Entity<Opdrachtgever>()
                .Property(e => e.Telephone)
                .HasMaxLength(20)
                .HasColumnType("VARCHAR(20)")
                .IsRequired();

            modelBuilder.Entity<Medewerker>()
                .Property(e => e.Token)
                .HasMaxLength(100)
                .HasColumnType("VARCHAR(100)");


            // Sollicitatie

            modelBuilder.Entity<Sollicitatie>()
                .Property(e => e.Status)
                .IsRequired()
                .HasConversion(
                    v => v.ToString(),
                    v => Enum.Parse<StatusEnum>(v));

            modelBuilder.Entity<Sollicitatie>()
                .Property(e => e.Medewerker_akkoord)
                .HasColumnType("tinyint(1)")
                .HasDefaultValue(0)
                .IsRequired();

            modelBuilder.Entity<Sollicitatie>()
                .Property(e => e.Opdrachtgever_akkoord)
                .HasColumnType("tinyint(1)")
                .HasDefaultValue(0)
                .IsRequired();

            // Vacature

            modelBuilder.Entity<Vacature>()
                .Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnType("VARCHAR(255)")
                .IsRequired();

            modelBuilder.Entity<Vacature>()
                .Property(e => e.Description)
                .HasColumnType("TEXT");

            modelBuilder.Entity<Vacature>()
                .Property(e => e.Uitstroomrichting)
                .IsRequired()
                .HasConversion(
                    v => v.ToString(),
                    v => Enum.Parse<Specialization>(v));

            modelBuilder.Entity<Vacature>()
                .Property(e => e.Location)
                .HasMaxLength(255)
                .HasColumnType("VARCHAR(255)")
                .IsRequired();

            modelBuilder.Entity<Vacature>()
                .Property(e => e.Startdate)
                .HasColumnType("Datetime(6)")
                .IsRequired();

            modelBuilder.Entity<Vacature>()
                .Property(e => e.Enddate)
                .HasColumnType("Datetime(6)")
                .IsRequired();

        }

    }

}