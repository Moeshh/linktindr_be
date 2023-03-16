using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbcontext.Classes
{
    public enum UsertypeEnum
    {
        Medewerker,
        Talentmanager,
        Opdrachtgever
    }

    public class Users
    {
        public int Id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public UsertypeEnum usertype { get; set; }
    }

    public class Users_noid
    {
        public string email { get; set; }
        public string password { get; set; }
        public UsertypeEnum usertype { get; set; }
    }

    public class Users_barebone
    {
        public string email { get; set; }
        public string password { get; set; }
    }

    public class Users_talentmanager
    {
        public string email { get; set; }
        public string password { get; set; }
        public TalentManager talentManager { get; set; }
    }
}
