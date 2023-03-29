namespace Linktindr_be.Dto
{
    public class SavePlaatsingDto
    {
        public int MedewerkerId { get; set; }
        public int SollicitatieId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Active { get; set; }
    }

}
