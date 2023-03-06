namespace dbcontext {
    public class Medewerker {
        public int Id { get; set; }
        public int IdTalentManager { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PostCode { get; set; }
        public string HouseNumber { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public int Radius { get; set; }
        public int Specialization { get; set; }
        public string Photo { get; set; }
        public string ProfileText { get; set; }
    }
    public class Medewerker_NoId
    {
        public int IdTalentManager { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PostCode { get; set; }
        public string HouseNumber { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public int Radius { get; set; }
        public int Specialization { get; set; }
        public string Photo { get; set; }
        public string ProfileText { get; set; }
    }
}