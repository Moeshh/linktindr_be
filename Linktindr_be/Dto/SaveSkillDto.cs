using dbcontext.Classes;

namespace Linktindr_be.Dto {
    public class SaveSkillDto {
        public string Language { get; set; }
        public string Level { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int MedewerkerId { get; set; }
    }
}
