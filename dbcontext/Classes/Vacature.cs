namespace dbcontext.Classes
{
    public class Vacatures {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Specialization Uitstroomrichting { get; set; }
        public string Location { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime Enddate { get; set; }
        public virtual Opdrachtgever Opdrachtgever { get; set; }
    }
    public class Vacatures_NoId {
        public string Title { get; set; }
        public string Description { get; set; }
        public Specialization Uitstroomrichting { get; set; }
        public string Location { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime Enddate { get; set; }
        public int OpdrachtgeverId { get; set; }
    }

    public class VacaturesDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Specialization Uitstroomrichting { get; set; }
        public string Location { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime Enddate { get; set; }
        public int OpdrachtgeverId { get; set; }
        public string OpdrachtgeverName { get; set; }
        public string OpdrachtgeverEmail { get; set; }
        public int OpdrachtgeverTelephone { get; set; }

        public VacaturesDTO() { }

        public VacaturesDTO(Vacatures v)
        {
            this.Id = v.Id;
            this.Title = v.Title;
            this.Description = v.Description;
            this.Uitstroomrichting = v.Uitstroomrichting;
            this.Location = v.Location;
            this.Startdate = v.Startdate;
            this.Enddate = v.Enddate;

            this.OpdrachtgeverId = v.Opdrachtgever.Id;
            this.OpdrachtgeverName = v.Opdrachtgever.Name;
            this.OpdrachtgeverEmail = v.Opdrachtgever.Email;
            this.OpdrachtgeverTelephone = v.Opdrachtgever.Telephone;
        }
    }

    public class VacaturesInputDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Specialization Uitstroomrichting { get; set; }
        public string Location { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime Enddate { get; set; }
        public int OpdrachtgeverId { get; set; }
    }
}