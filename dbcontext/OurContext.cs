using dbcontext.Classes;
using Microsoft.EntityFrameworkCore;

namespace dbcontext
{
    public class OurContext : DbContext
    {
        public OurContext(DbContextOptions options) : base(options) { }
        public DbSet<Medewerker> medewerker { get; set; }
        public DbSet<Vacatures> vacatures { get; set; }
        public DbSet<TalentManager> talentmanager { get; set; }
        public DbSet<Sollicitatie> sollicitatie { get; set; }
        public DbSet<Opdrachtgever> opdrachtgever { get; set; }
        public DbSet<Plaatsing> plaatsing { get; set; }
        public DbSet<Users> users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            //Talentmanager
            modelBuilder.Entity<TalentManager>()
                .Property(e => e.FirstName)
                .HasMaxLength(255)
                .HasColumnType("VARCHAR(255)")
                .IsRequired();

            modelBuilder.Entity<TalentManager>()
                .Property(e => e.LastName)
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
                .HasMaxLength(10)
                .HasColumnType("INT(10)")
                .IsRequired();

            modelBuilder.Entity<TalentManager>()
                .HasMany(t => t.Medewerkers);

            //Medewerker
            modelBuilder.Entity<Medewerker>()
                .Property(e => e.FirstName)
                .HasMaxLength(255)
                .HasColumnType("VARCHAR(255)")
                .IsRequired();

            modelBuilder.Entity<Medewerker>()
                .Property(e => e.LastName)
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
                .HasMaxLength(10)
                .HasColumnType("INT(10)")
                .IsRequired();

            modelBuilder.Entity<Medewerker>()
                .Property(e => e.Radius)
                .HasMaxLength(3)
                .HasColumnType("INT(3)")
                .IsRequired();

            var specializationEnumValues = Enum.GetValues(typeof(Specialization))
                .Cast<Specialization>()
                .Select(s => s.GetDescription())
                .ToList();

            var allowedValues = string.Join("', '", specializationEnumValues);
            
            modelBuilder.Entity<Medewerker>()
                .Property(e => e.Uitstroomrichting)
                .HasConversion<string>()
                .HasColumnType($"ENUM('{allowedValues}')")
                .IsRequired();

            modelBuilder.Entity<Medewerker>()
                .Property(e => e.Photo)
                .HasMaxLength(255)
                .HasColumnType("VARCHAR(255)");

            modelBuilder.Entity<Medewerker>()
                .Property(e => e.ProfileText)
                .HasColumnType("TEXT");

            modelBuilder.Entity<Medewerker>()
                .HasOne(m => m.TalentManager);

            //Vacature
            modelBuilder.Entity<Vacatures>()
                .Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnType("VARCHAR(255)")
                .IsRequired();

            modelBuilder.Entity<Vacatures>()
                .Property(e => e.Description)
                .HasColumnType("TEXT");

            modelBuilder.Entity<Vacatures>()
                .Property(e => e.Uitstroomrichting)
                .HasConversion<string>()
                .HasColumnType($"ENUM('{allowedValues}')")
                .IsRequired();

            modelBuilder.Entity<Vacatures>()
                .Property(e => e.Location)
                .HasMaxLength(255)
                .HasColumnType("VARCHAR(255)")
                .IsRequired();

            modelBuilder.Entity<Vacatures>()
                .Property(e => e.Startdate)
                .HasColumnType("Datetime(6)")
                .IsRequired();

            modelBuilder.Entity<Vacatures>()
                .Property(e => e.Enddate)
                .HasColumnType("Datetime(6)")
                .IsRequired();

            //opdrachtgever
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
                .HasMaxLength(10)
                .HasColumnType("INT(10)")
                .IsRequired();

            //Sollicitatie
            modelBuilder.Entity<Sollicitatie>()
                .Property(e => e.Status)
                .HasColumnType($"ENUM('{string.Join("', '", Enum.GetNames(typeof(StatusEnum)))}')")
                .HasDefaultValue(StatusEnum.Match)
                .IsRequired();

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

            //Users
            modelBuilder.Entity<Users>()
                .Property(e => e.email)
                .HasMaxLength(255)
                .HasColumnType("VARCHAR(255)")
                .IsRequired();
            modelBuilder.Entity<Users>()
                .Property(e => e.password)
                .HasMaxLength(255)
                .HasColumnType("VARCHAR(255)")
                .IsRequired();
            modelBuilder.Entity<Users>()
                .Property(e => e.usertype)
                .HasColumnType($"ENUM('{string.Join("', '", Enum.GetNames(typeof(UsertypeEnum)))}')")
                .HasDefaultValue(UsertypeEnum.Medewerker)
                .IsRequired();
            //Plaatsing niet nodig?
        }

    }

}