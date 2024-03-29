﻿namespace dbcontext.Classes
{
    public class Vacature {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Specialization Uitstroomrichting { get; set; }
        public string Location { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime Enddate { get; set; }
        public virtual Opdrachtgever Opdrachtgever { get; set; }
    }

}