using dbcontext;
using dbcontext.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Linktindr_be.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class SollicitatieController : ControllerBase {
        OurContext OC;
        public SollicitatieController(OurContext oC) {
            OC = oC;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<SollicitatieDTO> Get() {
            return OC.Sollicitatie.Include(s => s.Medewerker)
                .Include(s => s.Medewerker.TalentManager)
                .Include(s => s.Vacature)
                .Include(s => s.Vacature.Opdrachtgever)
                .Select(s => new SollicitatieDTO(s))
                .ToList();
        }

        // GET (specific) api/<SollicitatieController>/{id}
        [HttpGet("{id}")]
        public SollicitatieDTO Get(int id) {
            if(OC.Sollicitatie.Find(id) == null) {
                SollicitatieDTO sdto = new SollicitatieDTO();
                sdto.Id = -1;
                return sdto;
            }

            SollicitatieDTO s = new SollicitatieDTO(OC.Sollicitatie.Include(s => s.Medewerker)
                .Include(s => s.Medewerker.TalentManager)
                .Include(s => s.Vacature)
                .Include(s => s.Vacature.Opdrachtgever)
                .FirstOrDefault(s => s.Id == id));

            return s;
        }

        // ADD api/<SollicitatieController>/add
        [HttpPost("add")]
        public string Add(Sollicitatie_NoId sni) {
            Sollicitatie s = new Sollicitatie();

            if(OC.Medewerker.Find(sni.MedewerkerId) == null || OC.Vacatures.Find(sni.VacatureId) == null) {
                return "gefaald";
            }

            s.Medewerker = OC.Medewerker.Find(sni.MedewerkerId);
            s.Vacature = OC.Vacatures.Find(sni.VacatureId);
            s.Status = 0;
            s.Medewerker_akkoord = false;
            s.Opdrachtgever_akkoord = false;

            OC.Add(s);
            OC.SaveChanges();
            return "gelukt";
        }

        // PUT api/<SollicitatieController>/update
        [HttpPut("update")]
        public string Put(SollicitatieInputDTO s) {
            Sollicitatie soc = OC.Sollicitatie.Find(s.Id);
            if(soc == null) {
                return "gefaald";
            }

            soc.Medewerker = OC.Medewerker.Find(s.MedewerkerId);
            soc.Vacature = OC.Vacatures.Find(s.VacatureId);
            soc.Status = s.Status;
            soc.Medewerker_akkoord = s.Medewerker_akkoord;
            soc.Opdrachtgever_akkoord = s.Opdrachtgever_akkoord;

            OC.Sollicitatie.Update(soc);
            OC.SaveChanges();

            return "gelukt";
        }

        // DELETE api/<SollicitatieController>/delete
        [HttpDelete("delete")]
        public string Delete(int id) {
            Sollicitatie s = OC.Sollicitatie.Find(id);
            if(s == null) {
                return "gefaald";
            }

            OC.Sollicitatie.Remove(s);
            OC.SaveChanges();

            return "gelukt";
        }
    }
}
