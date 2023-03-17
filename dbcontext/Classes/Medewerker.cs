using System.ComponentModel;

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
        public virtual TalentManager TalentManager { get; set; }
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

    public class MedewerkerInputDTO
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
        public int TalentManagerId { get; set; }
    }
}