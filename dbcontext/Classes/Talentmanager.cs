namespace dbcontext.Classes {
    public class TalentManager : User {
        public virtual ICollection<Medewerker>? Medewerkers { get; set; }

        public override UserType GetUserType()
        {
            return UserType.TALENTMANAGER;
        }

    }
}