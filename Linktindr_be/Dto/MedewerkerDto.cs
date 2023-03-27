using dbcontext.Classes;

namespace Linktindr_be.Dto
{
    public class MedewerkerDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PostCode { get; set; }
        public string HouseNumber { get; set; }
        public int Radius { get; set; }
        public Specialization Uitstroomrichting { get; set; }
        public string Photo { get; set; }
        public string ProfileText { get; set; }

        //variabelen van de bijbehorende talentmanager
        public int TalentManagerId { get; set; }
        public string TalentManagerName { get; set; }
        public string TalentManagerEmail { get; set; }
        public string TalentManagerTelephone { get; set; }

        public ICollection<SkillDto>? Skill { get; set; }

        public MedewerkerDto() { }

        public MedewerkerDto(Medewerker m)
        {
            this.Id = m.Id;
            this.Name = m.Name;
            this.DateOfBirth = m.DateOfBirth;
            this.PostCode = m.PostCode;
            this.HouseNumber = m.HouseNumber;
            this.Email = m.Email;
            this.Telephone = m.Telephone;
            this.Radius = m.Radius;
            this.Uitstroomrichting = m.Uitstroomrichting;
            this.Photo = m.Photo;
            this.ProfileText = m.ProfileText;

            this.TalentManagerId = m.TalentManager.Id;
            this.TalentManagerName = m.TalentManager.Name;
            this.TalentManagerEmail = m.TalentManager.Email;
            this.TalentManagerTelephone = m.TalentManager.Telephone;

            this.Skill = (ICollection<SkillDto>?)m.Skill;
        }
    }
}
