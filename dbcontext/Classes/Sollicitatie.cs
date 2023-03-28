namespace dbcontext.Classes {

    public class Sollicitatie {
        public int Id { get; set; }
        public Status Status { get; set; }
        public bool Medewerker_akkoord { get; set; }
        public bool Opdrachtgever_akkoord { get; set; }
        public virtual Medewerker Medewerker { get; set; }
        public virtual Vacature Vacature { get; set; }
    }


}