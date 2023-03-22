using dbcontext;
using dbcontext.Classes;
using Linktindr_be.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Linktindr_be.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class MedewerkerController : ControllerBase {
        
        private OurContext OC;
        
        public MedewerkerController(OurContext oC) {
            OC = oC;
        }

        // GET: api/<MedewerkerController>
        [HttpGet]
        public List<MedewerkerDTO> Get() {
            return OC.Medewerker.Include(m => m.TalentManager)
                .Select(m => new MedewerkerDTO(m))
                .ToList();
            /*
            List<Medewerker> test = System.IO.File.ReadAllLines("C:\\Users\\vivo-\\source\\repos\\Linktindr_be\\Linktindr_be\\dataSet_linktindr_werknemer.csv")
                .Skip(1)
                .Select(v => Medewerker.FromCsv(v))
                .ToList();
            
            return test;
            */
        }

        // GET (specific) api/<MedewerkerController>/{id}
        [HttpGet("{id}")]
        public MedewerkerDTO? Get(int id) {
            // Haal eerst de medewerker op. Met de ? geven we aan dat die null kan zijn
            Medewerker? m = OC.Medewerker.Include(m => m.TalentManager).FirstOrDefault(m => m.Id == id);

            // Als die null is dan is die niet gevonden dus dan kunnen we ook null 
            // terug geven. Dan is de response body leeg. 
            if (m == null)
                return null;

            // Hier is de medewerker dus bekend en die kan je omzetten
            return new MedewerkerDTO(m);
        }

        //GET (maak nieuwe medewerker aan) api/<MedewerkerController>/add
        [HttpPost("add")]
        public bool Add(Medewerker_NoId mni) {
            // Wordt deze nog wel gebruikt aangezien we een centrale endpoint
            // maken die alle users aanmaken

            // Haal de talent manager op. 
            TalentManager? t = OC.Talentmanager.Find(mni.TalentManagerId);

            // Als die niet gevonden kan worden dan geven we false terug. Namelijk je
            // wilt ervoor zorgen dat alleen bestaande foreign keys worden gebruikt
            if (t == null)
                return false;

            Medewerker m = new Medewerker();
            m.TalentManager = t;
            m.FirstName = mni.FirstName;
            m.LastName = mni.LastName;
            m.PostCode = mni.PostCode;
            m.HouseNumber = mni.HouseNumber;
            m.DateOfBirth = mni.DateOfBirth;
            m.PostCode = mni.PostCode;
            m.HouseNumber = mni.HouseNumber;
            m.Email = mni.Email;
            m.Telephone = mni.Telephone;
            m.Radius = mni.Radius;
            m.Uitstroomrichting = mni.Uitstroomrichting;
            m.Photo = mni.Photo;
            m.ProfileText = mni.ProfileText;

            OC.Add(m);
            OC.SaveChanges();
            return true;
        }

        // PUT api/<MedewerkerController>/update
        [HttpPut("update")]
        public bool Put(MedewerkerInputDTO m) {
            // Medewerker kan ook mogelijk niet gevonden worden dus ? erbij
            Medewerker? moc = OC.Medewerker.Find(m.Id);

            // Als die niet is gevonden geven we iets terug om aan te geven dat
            // het niet gelutk is
            if(moc == null) {
                // Hier stond return "gefaald" echter strings zijn onhandige error 
                // codes dus vaak wordt hier een int of een boolean gebruikt. Dat
                // is namelijk korter
                return false;
            }

            // Haal de talent manager op. 
            TalentManager? t = OC.Talentmanager.Find(m.TalentManagerId);

            // Als die niet gevonden kan worden dan geven we false terug. Namelijk je
            // wilt ervoor zorgen dat alleen bestaande foreign keys worden gebruikt
            if (t == null)
                return false;

            // Nu pas kunnen we het object aanpassen nadat alle referenties / foreign
            // keys zijn geverifieerd
            moc.TalentManager = t;
            moc.FirstName = m.FirstName;
            moc.LastName = m.LastName;
            moc.PostCode = m.PostCode;
            moc.HouseNumber = m.HouseNumber;
            moc.DateOfBirth = m.DateOfBirth;
            moc.PostCode = m.PostCode;
            moc.HouseNumber = m.HouseNumber;
            moc.Email = m.Email;
            moc.Telephone = m.Telephone;
            moc.Radius = m.Radius;
            moc.Uitstroomrichting = Enum.Parse<Specialization>(m.Uitstroomrichting);
            moc.Photo = m.Photo;
            moc.ProfileText = m.ProfileText;

            OC.Medewerker.Update(moc);
            OC.SaveChanges();

            return true;
        }

        // DELETE api/<MedewerkerController>/delete
        [HttpDelete("delete")]
        public bool Delete(int id) {
            // Medewerker kan ook mogelijk niet gevonden worden dus ? erbij
            Medewerker? m = OC.Medewerker.Find(id);
            if(m == null) {
                return false;
            }

            OC.Medewerker.Remove(m);
            OC.SaveChanges();

            return true;
        }
    }
}
