namespace dbcontext {
    public class Plaatsing {
        public int Id { get; set; }
        public virtual Sollicitatie Sollicitatie { get; set; }
    }
}