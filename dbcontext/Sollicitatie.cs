namespace dbcontext {
    public class Sollicitatie {
        public int Id { get; set; }
        public int Medewerker_id { get; set; }
        public int Vacature_id { get; set; }
        public int Status { get; set; }
        public bool Medewerker_akkoord { get; set; }
        public bool Werkgever_akkoord { get; set; }
    }
}