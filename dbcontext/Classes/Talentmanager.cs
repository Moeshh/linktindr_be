namespace dbcontext.Classes {
    public class TalentManager : User {
        public virtual ICollection<Medewerker>? Medewerkers { get; set; }
    }
}