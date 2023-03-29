namespace dbcontext.Classes
{
    public class Plaatsing
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public virtual Sollicitatie Sollicitatie { get; set; }
        public bool Active { get; set; }
    }
    
}