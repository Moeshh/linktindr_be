namespace Linktindr_be.DTO {
    public class TalentmanagerDTO {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Telephone { get; set; }
    }

    public class TalentmanagerDTOCreate {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Telephone { get; set; }
    }

    public class TalentmanagerDTOUpdate {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Telephone { get; set; }
    }
}
