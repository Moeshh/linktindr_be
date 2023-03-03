namespace dbcontext {
    public class Medewerker {
        public int Id { get; set; }
        public int Talentmanager_id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Dateofbirth { get; set; }
        public string Postcode { get; set; }
        public string Housenumber { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public int Radius { get; set; }
        public int Specialization { get; set; }
        public string Photo { get; set; }
        public string Profiletext { get; set; }
    }
}