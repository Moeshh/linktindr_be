namespace Linktindr_be.Dto
{
    public class SaveVacatureDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Uitstroomrichting { get; set; }
        public string Location { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime Enddate { get; set; }
        public int OpdrachtgeverId { get; set; }
    }
}
