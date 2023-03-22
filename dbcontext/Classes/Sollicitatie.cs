using System.ComponentModel;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace dbcontext.Classes {
    public enum StatusEnum {
        Match,
        Sollicitatie,
        Bedenktijd,
        Accept,
        Decline
    }
    public class Sollicitatie {
        public int Id { get; set; }
        public StatusEnum Status { get; set; }
        public bool? Medewerker_akkoord { get; set; }
        public bool? Opdrachtgever_akkoord { get; set; }
        public virtual Medewerker Medewerker { get; set; }
        public virtual Vacatures Vacature { get; set; }
        //als de akkoorden bools zijn, hoe bepalen we dan het verschil tussen de default-waarde voor de keuze is gemaakt en een echte Ja of Nee?
    }
    public class Sollicitatie_NoId
    {
        public int MedewerkerId { get; set; }
        public int VacatureId { get; set; }
    }
    public class SollicitatieDTO
    {
        public int Id { get; set; }
        public StatusEnum Status { get; set; }
        public bool Medewerker_akkoord { get; set; }
        public bool Opdrachtgever_akkoord { get; set; }

        //variabelen van gerelateerde medewerker
        public int MedewerkerId { get; set; }
        public string MedewerkerFirstName { get; set; }
        public string MedewerkerLastName { get; set; }
        public DateTime MedewerkerDateOfBirth { get; set; }
        public string MedewerkerPostCode { get; set; }
        public string MedewerkerHouseNumber { get; set; }
        public string MedewerkerEmail { get; set; }
        public int MedewerkerTelephone { get; set; }
        public int MedewerkerRadius { get; set; }
        public Specialization MedewerkerUitstroomrichting { get; set; } = Specialization.DevOps;
        public string MedewerkerPhoto { get; set; }
        public string MedewerkerProfileText { get; set; }
        public int MedewerkerTalentManagerId { get; set; }

        //variabelen van gerelateerde vacature
        public int VacatureId { get; set; }
        public string VacatureTitle { get; set; }
        public string VacatureDescription { get; set; }
        public Specialization VacatureUitstroomrichting { get; set; }
        public string VacatureLocation { get; set; }
        public DateTime VacatureStartdate { get; set; }
        public DateTime VacatureEnddate { get; set; }
        public int VacatureOpdrachtgeverId { get; set; }

        public SollicitatieDTO() { }
        public SollicitatieDTO(Sollicitatie s)
        {
            this.Id = s.Id;
            this.Status = s.Status;
            this.Medewerker_akkoord = s.Medewerker_akkoord;
            this.Opdrachtgever_akkoord = s.Opdrachtgever_akkoord;

            this.MedewerkerId = s.Medewerker.Id;
            this.MedewerkerFirstName = s.Medewerker.FirstName;
            this.MedewerkerLastName = s.Medewerker.LastName;
            this.MedewerkerDateOfBirth = s.Medewerker.DateOfBirth;
            this.MedewerkerPostCode = s.Medewerker.PostCode;
            this.MedewerkerHouseNumber = s.Medewerker.HouseNumber;
            this.MedewerkerEmail = s.Medewerker.Email;
            this.MedewerkerTelephone = s.Medewerker.Telephone;
            this.MedewerkerRadius = s.Medewerker.Radius;
            this.MedewerkerUitstroomrichting = s.Medewerker.Uitstroomrichting;
            this.MedewerkerPhoto = s.Medewerker.Photo;
            this.MedewerkerProfileText = s.Medewerker.ProfileText;
            this.MedewerkerTalentManagerId = s.Medewerker.TalentManager.Id;

            this.VacatureId = s.Vacature.Id;
            this.VacatureTitle = s.Vacature.Title;
            this.VacatureDescription = s.Vacature.Description;
            this.VacatureUitstroomrichting = s.Vacature.Uitstroomrichting;
            this.VacatureLocation = s.Vacature.Location;
            this.VacatureStartdate = s.Vacature.Startdate;
            this.VacatureEnddate = s.Vacature.Enddate;
            this.VacatureOpdrachtgeverId = s.Vacature.Opdrachtgever.Id;
        }
    }

    public class SollicitatieInputDTO
    {
        public int Id { get; set; }
        public StatusEnum Status { get; set; }
        public bool Medewerker_akkoord { get; set; }
        public bool Opdrachtgever_akkoord { get; set; }
        public int MedewerkerId { get; set; }
        public int VacatureId { get; set; }
    }
}