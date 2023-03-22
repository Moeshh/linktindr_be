using dbcontext;
using dbcontext.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Linktindr_be.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class MedewerkerController : ControllerBase {
        OurContext OC;
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
        public MedewerkerDTO Get(int id) {
            if(OC.Medewerker.Find(id) == null) {
                MedewerkerDTO mdto = new MedewerkerDTO();
                mdto.Id = -1;
                mdto.FirstName = "Invalid";
                mdto.LastName = "ID";
                return mdto;
            }

            MedewerkerDTO m = new MedewerkerDTO(OC.Medewerker.Include(m => m.TalentManager)
                .FirstOrDefault(m => m.Id == id));

            return m;
        }

        //GET (maak nieuwe medewerker aan) api/<MedewerkerController>/add
        [HttpPost("add")]
        public string Add(Medewerker_NoId mni) {
            Medewerker m = new Medewerker();

            m.TalentManager = OC.Talentmanager.Find(mni.TalentManagerId);
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
            return "gelukt";
        }

        // PUT api/<MedewerkerController>/update
        [HttpPut("update")]
        public string Put(MedewerkerInputDTO m) {
            Medewerker moc = OC.Medewerker.Find(m.Id);
            if(moc == null) {
                return "gefaald";
            }

            TalentManager t = OC.Talentmanager.Find(m.TalentManagerId);

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
            moc.Uitstroomrichting = m.Uitstroomrichting;
            moc.Photo = m.Photo;
            moc.ProfileText = m.ProfileText;

            OC.Medewerker.Update(moc);
            OC.SaveChanges();

            return "gelukt";
        }

        // DELETE api/<MedewerkerController>/delete
        [HttpDelete("delete")]
        public string Delete(int id) {
            Medewerker m = OC.Medewerker.Find(id);
            if(m == null) {
                return "gefaald";
            }

            OC.Medewerker.Remove(m);
            OC.SaveChanges();

            return "gelukt";
        }
    }
}
