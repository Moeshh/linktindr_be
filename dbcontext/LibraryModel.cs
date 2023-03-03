using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbcontext {
    public class Medewerker_ {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Postcode { get; set; }
        public string HouseNumber { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Radius { get; set; }
        public UitstroomRichtingEnum_ UitstroomRichting { get; set; }
        public string Photo { get; set; }
        public string ProfileText { get; set; }
        public int Talentmanager_id { get; set; }
    }
    public enum UitstroomRichtingEnum_ {
        [Description("Devops")] DevOps,
        [Description("C# Programmeur")] Cprogrammeur,
        [Description("Informatie Analist")] InfoAnalist
    }
    public class TalentManager_ {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Telephone { get; set; }

    }
}
