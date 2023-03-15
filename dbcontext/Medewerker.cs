using System.ComponentModel;

namespace dbcontext {

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
    public class Medewerker_NoId {
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
        public virtual TalentManager TalentManager { get; set; }
    }
}