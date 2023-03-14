namespace dbcontext.Classes
{
    public class Vacature
    {
        public int Id { get; set; }
        public int Opdrachtgever_id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Uitstroomrichting { get; set; }
        public string Location { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime Einddate { get; set; }
    }
    public class Vacature_NoId
    {
        public int Opdrachtgever_id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Uitstroomrichting { get; set; }
        public string Location { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime Einddate { get; set; }
    }
}