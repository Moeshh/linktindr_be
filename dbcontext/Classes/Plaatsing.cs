namespace dbcontext.Classes
{
    public class Plaatsing
    {
        public int Id { get; set; }

        public DateTime Started { get; set; }

        public virtual Medewerker Medewerker { get; set; }

        public virtual Sollicitatie Sollicitatie { get; set; }
    }
    
}