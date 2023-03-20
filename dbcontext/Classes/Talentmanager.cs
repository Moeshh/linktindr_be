namespace dbcontext.Classes {
    public class TalentManager {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Telephone { get; set; }
        public virtual ICollection<Medewerker> Medewerkers { get; set; }
    }
    public class TalentManager_NoId {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Telephone { get; set; }
    }
    public class TalentManagerDTO {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Telephone { get; set; }

        public TalentManagerDTO() {

        }
        public TalentManagerDTO(TalentManager t) {
            this.Id = t.Id;
            this.FirstName = t.FirstName;
            this.LastName = t.LastName;
            this.Email = t.Email;
            this.Telephone = t.Telephone;
        }

        public static TalentManager FromCsv(string csvLine) {
            string[] values = csvLine.Split(';');
            TalentManager tidto = new TalentManager();
            tidto.FirstName = Convert.ToString(values[0]);
            tidto.LastName = Convert.ToString(values[1]);
            tidto.Email = Convert.ToString(values[2]);
            tidto.Telephone = Convert.ToInt32(values[6]);
            return tidto;
        }
    }
    public class TalentManagerInputDTO {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Telephone { get; set; }

    }
}