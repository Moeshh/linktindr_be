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
        
        private readonly OurContext OC;

        public MedewerkerController(OurContext OC) {
            this.OC = OC;
        }

        // GET: api/<MedewerkerController>
        [HttpGet]
        public List<MedewerkerDto> Get() {
            return OC.Medewerker.Include(m => m.TalentManager)
                .Select(m => new MedewerkerDto(m))
                .ToList();
        }

        // GET (specific) api/<MedewerkerController>/{id}
        [HttpGet("{id}")]
        public MedewerkerDto? Get(int id) {
            // Haal eerst de medewerker op. Met de ? geven we aan dat die null kan zijn
            Medewerker? m = OC.Medewerker.Include(m => m.TalentManager).FirstOrDefault(m => m.Id == id);

            // Als die null is dan is die niet gevonden dus dan kunnen we ook null 
            // terug geven. Dan is de response body leeg. 
            if (m == null)
                return null;

            // Hier is de medewerker dus bekend en die kan je omzetten
            return new MedewerkerDto(m);
        }

        //GET (maak nieuwe medewerker aan) api/<MedewerkerController>/add
        [HttpPost("add")]
        public bool Add(SaveMedewerkerDto dto) {
            // Wordt deze nog wel gebruikt aangezien we een centrale endpoint
            // maken die alle users aanmaken

            // Haal de talent manager op. 
            TalentManager? t = OC.TalentManager.Find(dto.TalentManagerId);

            // Als die niet gevonden kan worden dan geven we false terug. Namelijk je
            // wilt ervoor zorgen dat alleen bestaande foreign keys worden gebruikt
            if (t == null)
                return false;

            Medewerker m = new Medewerker();
            m.TalentManager = t;
            m.Name = dto.Name;
            m.PostCode = dto.PostCode;
            m.HouseNumber = dto.HouseNumber;
            m.DateOfBirth = dto.DateOfBirth;
            m.PostCode = dto.PostCode;
            m.HouseNumber = dto.HouseNumber;
            m.Email = dto.Email;
            m.Password = dto.Password;
            m.Telephone = dto.Telephone;
            m.Radius = dto.Radius;
            m.Uitstroomrichting = Enum.Parse<Specialization>(dto.Uitstroomrichting);
            m.Photo = dto.Photo;
            m.ProfileText = dto.ProfileText;

            OC.Add(m);
            OC.SaveChanges();
            return true;
        }

        // PUT api/<MedewerkerController>/update
        // api/medewerker/1/update
        [HttpPut("update/{id:int}")]
        public bool Put(int id, [FromBody] SaveMedewerkerDto m) {
            // Medewerker kan ook mogelijk niet gevonden worden dus ? erbij
            Medewerker? dbMedewerker = OC.Medewerker.Find(id);

            // Als die niet is gevonden geven we iets terug om aan te geven dat
            // het niet gelutk is
            if(dbMedewerker == null) {
                // Hier stond return "gefaald" echter strings zijn onhandige error 
                // codes dus vaak wordt hier een int of een boolean gebruikt. Dat
                // is namelijk korter
                return false;
            }

            // Haal de talent manager op. 
            TalentManager? t = OC.TalentManager.Find(m.TalentManagerId);

            // Als die niet gevonden kan worden dan geven we false terug. Namelijk je
            // wilt ervoor zorgen dat alleen bestaande foreign keys worden gebruikt
            if (t == null)
                return false;

            // Nu pas kunnen we het object aanpassen nadat alle referenties / foreign
            // keys zijn geverifieerd
            dbMedewerker.TalentManager = t;
            dbMedewerker.Name = m.Name;
            dbMedewerker.PostCode = m.PostCode;
            dbMedewerker.HouseNumber = m.HouseNumber;
            dbMedewerker.DateOfBirth = m.DateOfBirth;
            dbMedewerker.PostCode = m.PostCode;
            dbMedewerker.HouseNumber = m.HouseNumber;
            dbMedewerker.Email = m.Email;
            dbMedewerker.Telephone = m.Telephone;
            dbMedewerker.Radius = m.Radius;
            dbMedewerker.Uitstroomrichting = Enum.Parse<Specialization>(m.Uitstroomrichting);
            dbMedewerker.Photo = m.Photo;
            dbMedewerker.ProfileText = m.ProfileText;

            OC.Medewerker.Update(dbMedewerker);
            OC.SaveChanges();

            return true;
        }

        // DELETE api/<MedewerkerController>/delete
        [HttpDelete("delete/{id:int}")]
        public bool Delete(int id) {
            // Medewerker kan ook mogelijk niet gevonden worden dus ? erbij
            Medewerker? dbMedewerker = OC.Medewerker.Find(id);
            if(dbMedewerker == null) {
                return false;
            }

            OC.Medewerker.Remove(dbMedewerker);
            OC.SaveChanges();

            return true;
        }
    }
}
