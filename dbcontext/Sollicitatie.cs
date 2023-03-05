namespace dbcontext {
    public class Sollicitatie {
        public int Id { get; set; }
        public int IdMedewerker { get; set; }
        public int IdVacature { get; set; }
        public int Status { get; set; }
        public bool Medewerker_akkoord { get; set; }
        public bool Werkgever_akkoord { get; set; }
        //als de akkoorden bools zijn, hoe bepalen we dan het verschil tussen de default-waarde voor de keuze is gemaakt en een echte Ja of Nee?
    }
    public class Sollicitatie_NoId
    {
        public int IdMedewerker { get; set; }
        public int IdVacature { get; set; }
        public int Status { get; set; }
        public bool Medewerker_akkoord { get; set; }
        public bool Werkgever_akkoord { get; set; }
    }
}