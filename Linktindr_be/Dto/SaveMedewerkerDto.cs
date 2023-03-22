using dbcontext.Classes;

namespace Linktindr_be.Dto
{
    public class SaveMedewerkerDto
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PostCode { get; set; }
        public string HouseNumber { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public int Radius { get; set; }
        public string Uitstroomrichting { get; set; }
        public string Photo { get; set; }
        public string ProfileText { get; set; }
        public int TalentManagerId { get; set; }
    }
}
