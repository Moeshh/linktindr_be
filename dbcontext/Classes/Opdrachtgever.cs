namespace dbcontext.Classes
{
    public class Opdrachtgever : User
    {
        public virtual ICollection<Vacature>? Vacatures { get; set; }
        public override UserType GetUserType()
        {
            return UserType.OPDRACHTGEVER;
        }

    }
}