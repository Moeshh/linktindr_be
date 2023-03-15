namespace dbcontext {
    public class Vacatures {
        public int Id { get; set; }
        //public int Opdrachtgever_id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Specialization Uitstroomrichting { get; set; }
        public string Location { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime Enddate { get; set; }
    }
    public class Vacature_NoId
    {
        //public int Opdrachtgever_id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Specialization Uitstroomrichting { get; set; }
        public string Location { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime Enddate { get; set; }
        public virtual Opdrachtgever Opdrachtgever { get; set; }
    }
}