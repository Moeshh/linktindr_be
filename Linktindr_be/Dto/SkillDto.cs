using dbcontext.Classes;

namespace Linktindr_be.Dto {
    public class SkillDto {
        public int Id { get; set; }
        public Language Language { get; set; }
        public Level Level { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int MedewerkerId { get; set; }

        public SkillDto() { }

        public SkillDto(Skill s) {
            this.Id = s.Id;
            this.Language = s.Language;
            this.Level = s.Level;
            this.Title = s.Title;
            this.Description = s.Description;

            this.MedewerkerId = s.Medewerker.Id;
        }
    }
}
