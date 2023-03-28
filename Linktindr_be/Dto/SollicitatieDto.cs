using dbcontext.Classes;

namespace Linktindr_be.Dto
{
    public class SollicitatieDto
    {
        public int Id { get; set; }
        public Status Status { get; set; }
        public bool? Medewerker_akkoord { get; set; }
        public bool? Opdrachtgever_akkoord { get; set; }

        //variabelen van gerelateerde medewerker
        public int MedewerkerId { get; set; }
        public string MedewerkerName { get; set; }
        public DateTime MedewerkerDateOfBirth { get; set; }
        public string MedewerkerPostCode { get; set; }
        public string MedewerkerHouseNumber { get; set; }
        public string MedewerkerEmail { get; set; }
        public string MedewerkerTelephone { get; set; }
        public int MedewerkerRadius { get; set; }
        public Specialization MedewerkerUitstroomrichting { get; set; }
        public string MedewerkerPhoto { get; set; }
        public string MedewerkerProfileText { get; set; }
        public int TalentManagerId { get; set; }

        //variabelen van gerelateerde vacature
        public int VacatureId { get; set; }
        public string VacatureTitle { get; set; }
        public string VacatureDescription { get; set; }
        public Specialization VacatureUitstroomrichting { get; set; }
        public string VacatureLocation { get; set; }
        public DateTime VacatureStartdate { get; set; }
        public DateTime VacatureEnddate { get; set; }

        public int OpdrachtgeverId { get; set; }
        public string OpdrachtgeverName { get; set; }

        public SollicitatieDto() { }

        public SollicitatieDto(Sollicitatie s)
        {
            this.Id = s.Id;
            this.Status = s.Status;
            this.Medewerker_akkoord = s.Medewerker_akkoord;
            this.Opdrachtgever_akkoord = s.Opdrachtgever_akkoord;

            this.MedewerkerId = s.Medewerker.Id;
            this.MedewerkerName = s.Medewerker.Name;
            this.MedewerkerDateOfBirth = s.Medewerker.DateOfBirth;
            this.MedewerkerPostCode = s.Medewerker.PostCode;
            this.MedewerkerHouseNumber = s.Medewerker.HouseNumber;
            this.MedewerkerEmail = s.Medewerker.Email;
            this.MedewerkerTelephone = s.Medewerker.Telephone;
            this.MedewerkerRadius = s.Medewerker.Radius;
            this.MedewerkerUitstroomrichting = s.Medewerker.Uitstroomrichting;
            this.MedewerkerPhoto = s.Medewerker.Photo;
            this.MedewerkerProfileText = s.Medewerker.ProfileText;
            this.TalentManagerId = s.Medewerker.TalentManager.Id;

            this.VacatureId = s.Vacature.Id;
            this.VacatureTitle = s.Vacature.Title;
            this.VacatureDescription = s.Vacature.Description;
            this.VacatureUitstroomrichting = s.Vacature.Uitstroomrichting;
            this.VacatureLocation = s.Vacature.Location;
            this.VacatureStartdate = s.Vacature.Startdate;
            this.VacatureEnddate = s.Vacature.Enddate;
            this.OpdrachtgeverId = s.Vacature.Opdrachtgever.Id;
            this.OpdrachtgeverName = s.Vacature.Opdrachtgever.Name;
        }
    }
}
