using dbcontext.Classes;

namespace Linktindr_be.Dto
{
    public class PlaatsingDto
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Active { get; set; }
        public int MedewerkerId { get; set; }
        public string MedewerkerName { get; set; }
        public int OpdrachtgeverId { get; set; }
        public string OpdrachtgeverName { get; set; }
        public int VacatureId { get; set; }
        public string VacatureTitle { get; set; }
        public string VacatureDescription { get; set; }
        public string VacatureLocation { get; set; }
        public int SollicitatieId { get; set; }

        public PlaatsingDto() { }

        public PlaatsingDto(Plaatsing s) {
            this.Id = s.Id;
            this.StartDate = s.StartDate;
            this.EndDate = s.EndDate;
            this.Active = s.Active;

            this.SollicitatieId = s.Sollicitatie.Id;

            this.MedewerkerId = s.Sollicitatie.Medewerker.Id;
            this.MedewerkerName = s.Sollicitatie.Medewerker.Name;

            this.VacatureId = s.Sollicitatie.Vacature.Id;
            this.VacatureTitle = s.Sollicitatie.Vacature.Title;
            this.VacatureDescription = s.Sollicitatie.Vacature.Description;
            this.VacatureLocation = s.Sollicitatie.Vacature.Location;

            this.OpdrachtgeverId = s.Sollicitatie.Vacature.Opdrachtgever.Id;
            this.OpdrachtgeverName = s.Sollicitatie.Vacature.Opdrachtgever.Name;
        }
    }
}
