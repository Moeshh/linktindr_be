namespace dbcontext.Classes
{
    public class Plaatsing
    {
        public int Id { get; set; }
        public int Sollicitatie_id { get; set; }
    }
    public class Plaatsing_NoId
    {
        public int Sollicitatie_id { get; set; }
    }
}