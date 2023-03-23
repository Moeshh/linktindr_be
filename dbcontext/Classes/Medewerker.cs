namespace dbcontext.Classes {
   

    public class Medewerker : User {
        public DateTime DateOfBirth { get; set; }
        public string PostCode { get; set; }
        public string HouseNumber { get; set; }
        public int Radius { get; set; }
        public Specialization Uitstroomrichting { get; set; }
        public string Photo { get; set; }
        public string ProfileText { get; set; }
        public virtual TalentManager TalentManager { get; set; }
        public virtual ICollection<Skill>? Skill { get; set; }
        public virtual ICollection<Medewerker>? Medewerkers { get; set; }
    }

}