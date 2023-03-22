namespace Linktindr_be.Dto
{
    public class PlaatsingDto
    {
        public int Id { get; set; }

        public DateTime Started { get; set; }

        public string MedewerkerName { get; set; }

        public int SollicitatieId { get; set; }
    }
}
