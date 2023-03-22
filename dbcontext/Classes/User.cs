using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbcontext.Classes {
    public abstract class User {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
    }
/*
    public class Users_noid {
        public string Email { get; set; }
        public string Password { get; set; }
        public UsertypeEnum Usertype { get; set; }
    }

    public class Users_barebone {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class Users_Talentmanager {
        public UsersDTO User { get; set; }
        public TalentManager_NoId TalentManager { get; set; }
    }

    public class Users_Medewerker {
        public Users_noid User { get; set; }
        public Medewerker_NoId Medewerker { get; set; }
    }

    public class Users_Opdrachtgever {
        public Users_noid User { get; set; }
        public Opdrachtgever_NoId Opdrachtgever { get; set; }
    }

    public class UsersDTO {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Usertype { get; set; }

        public UsersDTO() {
        }

        public UsersDTO(Users u) {
            this.Id = u.Id;
            this.Email = u.Email;
            this.Password = u.Password;
            this.Usertype = u.Usertype.ToString();
        }
    }

    public class CreateNewUserDTO {
        public string? Email { get; set; } 
        public string? Password { get; set; }
        public string? Usertype { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? Telephone { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? PostCode { get; set; }
        public string? HouseNumber { get; set; }
        public int? Radius { get; set; }
        public string? Uitstroomrichting { get; set; }
        public string? Photo { get; set; }
        public string? ProfileText { get; set; }
        //public int TalentManager { get; set; }
    }
*/
}
