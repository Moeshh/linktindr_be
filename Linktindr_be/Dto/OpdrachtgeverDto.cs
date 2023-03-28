using dbcontext.Classes;

namespace Linktindr_be.Dto
{
    public class OpdrachtgeverDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
        public ICollection<Vacature>? Vacatures { get; set; }

        public OpdrachtgeverDto() { }

        public OpdrachtgeverDto(Opdrachtgever o) {
            this.Id= o.Id;
            this.Email = o.Email;
            this.Password = o.Password;
            this.Telephone = o.Telephone;
            this.Name = o.Name;
        }
    }
}
