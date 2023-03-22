namespace Linktindr_be.Dto
{
    public class UpdateSollicitatieDto
    {
        public int MedewerkerId { get; set; }

        public int VacatureId { get; set; }
        public string Status { get; set; }
        public Boolean? Medewerker_akkoord { get; set; }
        public Boolean? Opdrachtgever_akkoord { get; set; }

    }
}
