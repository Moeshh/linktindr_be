namespace dbcontext.Classes {
    public class Skill {
        public int Id { get; set; }
        public Language Language { get; set; }
        public Level Level { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual Medewerker Medewerker { get; set; }
        public virtual ICollection<Skill>? Skills { get; set; }
    }
}
