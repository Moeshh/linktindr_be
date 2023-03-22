using dbcontext.Classes;

namespace Linktindr_be.Dto
{
    public class TalentManagerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }

        public TalentManagerDto()
        {

        }
        public TalentManagerDto(TalentManager t)
        {
            this.Id = t.Id;
            this.Name = t.Name;
            this.Email = t.Email;
            this.Telephone = t.Telephone;
        }
    }
}
