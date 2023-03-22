namespace dbcontext.Classes {
    public enum StatusEnum {
        MATCH,
        SOLLICITATIE,
        BEDENK,
        ACCEPT,
        DECLINE
    }

    public class Sollicitatie {
        public int Id { get; set; }
        public StatusEnum Status { get; set; }
        public Boolean? Medewerker_akkoord { get; set; }
        public Boolean? Opdrachtgever_akkoord { get; set; }
        public virtual Medewerker Medewerker { get; set; }
        public virtual Vacature Vacature { get; set; }
    }


}