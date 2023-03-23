namespace dbcontext.Classes
{
    public class Opdrachtgever : User
    {
        public override UserType GetUserType()
        {
            return UserType.OPDRACHTGEVER;
        }

    }
}