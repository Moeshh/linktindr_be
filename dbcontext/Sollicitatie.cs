using System.ComponentModel;
using static dbcontext.Sollicitatie;

namespace dbcontext {
    public enum StatusEnum {
        Match,
        Sollicitatie,
        Bedenktijd,
        Accept,
        Decline
    }
    public class Sollicitatie {

        public int Id { get; set; }
        public StatusEnum Status { get; set; }
        public bool Medewerker_akkoord { get; set; }
        public bool Opdrachtgever_akkoord { get; set; }
        public virtual Medewerker Medewerker { get; set; }
        public virtual Vacatures Vacature { get; set; }
        //als de akkoorden bools zijn, hoe bepalen we dan het verschil tussen de default-waarde voor de keuze is gemaakt en een echte Ja of Nee?
    }
    public class Sollicitatie_NoId
    {
        public StatusEnum Status { get; set; }
        public bool Medewerker_akkoord { get; set; }
        public bool Opdrachtgever_akkoord { get; set; }
        public int Medewerker_Id { get; set; }
        public int Vacature_Id { get; set; }
    }
}