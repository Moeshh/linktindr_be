using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace dbcontext.Classes {

    public enum Specialization {
        [Description("DevOps")]
        DevOps,
        [Description("Informatie Analist")]
        InformatieAnalist,
        [Description("C# Programmeur")]
        CSharpProgrammeur,
        [Description("Java Programmeur")]
        JavaProgrammeur
    }

    public static class EnumExtensions {
        public static string GetDescription(this Enum value) {
            var fieldInfo = value.GetType().GetField(value.ToString());
            var attributes = fieldInfo.GetCustomAttributes(
                typeof(DescriptionAttribute), false) as DescriptionAttribute[];
            return attributes != null && attributes.Length > 0 ? attributes[0].Description : value.ToString();
        }
    }

    public class Medewerker {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PostCode { get; set; }
        public string HouseNumber { get; set; }
        public int Telephone { get; set; }
        public int Radius { get; set; }
        public Specialization Uitstroomrichting { get; set; };
        public string Photo { get; set; }
        public string ProfileText { get; set; }
        public virtual TalentManager TalentManager { get; set; }

        public static Medewerker FromCsv(string csvLine) {
            string[] values = csvLine.Split(';');
            Medewerker midto = new Medewerker();
            midto.FirstName = Convert.ToString(values[0]);
            midto.LastName = Convert.ToString(values[1]);
            midto.DateOfBirth = Convert.ToDateTime(values[2]);
            midto.PostCode = Convert.ToString(values[3]);
            midto.HouseNumber = Convert.ToString(values[4]);
            midto.Email = Convert.ToString(values[5]);
            midto.Telephone = Convert.ToInt32(values[6]);
            midto.Radius = Convert.ToInt32(values[7]);
            Enum.TryParse(Convert.ToString(values[8]), out Specialization midtoUitstroomrichting);
            midto.Uitstroomrichting = midtoUitstroomrichting;
            midto.Photo = Convert.ToString(values[9]);
            midto.ProfileText = Convert.ToString(values[10]);
            //midto.TalentManagerId = Convert.ToInt32(values[11]);
            return midto;
        }
    }
    public class Medewerker_NoId
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PostCode { get; set; }
        public string HouseNumber { get; set; }
        public string Email { get; set; }
        public int Telephone { get; set; }
        public int Radius { get; set; }
        public Specialization Uitstroomrichting { get; set; }
        public string Photo { get; set; }
        public string ProfileText { get; set; }
        public int TalentManagerId { get; set; }
    }
    public class MedewerkerDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PostCode { get; set; }
        public string HouseNumber { get; set; }
        public string Email { get; set; }
        public int Telephone { get; set; }
        public int Radius { get; set; }
        public Specialization Uitstroomrichting { get; set; } = Specialization.DevOps;
        public string Photo { get; set; }
        public string ProfileText { get; set; }
        
        //variabelen van de bijbehorende talentmanager
        public int TalentManagerId { get; set; }
        public string TalentManagerFirstName { get; set; }
        public string TalentManagerLastName { get; set; }
        public string TalentManagerEmail { get; set; }
        public int TalentManagerTelephone { get; set; }

        public MedewerkerDTO() { }

        public MedewerkerDTO(Medewerker m)
        {
            this.Id = m.Id;
            this.FirstName = m.FirstName;
            this.LastName = m.LastName;
            this.DateOfBirth = m.DateOfBirth;
            this.PostCode = m.PostCode;
            this.HouseNumber = m.HouseNumber;
            this.Email = m.Email;
            this.Telephone = m.Telephone;
            this.Radius = m.Radius;
            this.Uitstroomrichting = m.Uitstroomrichting;
            this.Photo = m.Photo;
            this.ProfileText = m.ProfileText;

            this.TalentManagerId = m.TalentManager.Id;
            this.TalentManagerFirstName = m.TalentManager.FirstName;
            this.TalentManagerLastName = m.TalentManager.LastName;
            this.TalentManagerEmail = m.TalentManager.Email;
            this.TalentManagerTelephone = m.TalentManager.Telephone;
        }
    }

    public class MedewerkerInputDTO {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PostCode { get; set; }
        public string HouseNumber { get; set; }
        public string Email { get; set; }
        public int Telephone { get; set; }
        public int Radius { get; set; }
        public string Uitstroomrichting { get; set; }
        public string Photo { get; set; }
        public string ProfileText { get; set; }
        public int TalentManagerId { get; set; }

        
    }
}