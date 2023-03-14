namespace dbcontext.Classes
{
    public class Opdrachtgever
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Telephone { get; set; }
    }
    public class Opdrachtgever_NoId
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int Telephone { get; set; }
    }
}