namespace Linktindr_be.Dto
{
    public class UpdateSollicitatieDto
    {
        public int MedewerkerId { get; set; }

        public int VacatureId { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public bool Medewerker_akkoord { get; set; }
        public bool Opdrachtgever_akkoord { get; set; }

    }
}
