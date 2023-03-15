namespace dbcontext {
    public class TalentManager {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Telephone { get; set; }
        public virtual ICollection<Medewerker> Medewerkers { get; set; }
    }
    public class TalentManager_NoId
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Telephone { get; set; }
    }
}