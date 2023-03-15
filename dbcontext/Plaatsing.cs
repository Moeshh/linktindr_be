namespace dbcontext {
    public class Plaatsing {
        public int Id { get; set; }
        public virtual Sollicitatie Sollicitatie { get; set; }
    }
    public class Plaatsing_NoId
    {
        public int Sollicitatie_id { get; set; }
    }
}