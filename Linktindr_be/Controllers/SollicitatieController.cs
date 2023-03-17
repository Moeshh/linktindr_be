using dbcontext;
using dbcontext.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Linktindr_be.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SollicitatieController : ControllerBase
    {
        OurContext OU;
        public SollicitatieController(OurContext oU)
        {
            OU = oU;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<SollicitatieDTO> Get()
        {
            return OU.sollicitatie.Include(s => s.Medewerker)
                .Include(s => s.Medewerker.TalentManager)
                .Include(s => s.Vacature)
                .Include(s => s.Vacature.Opdrachtgever)
                .Select(s => new SollicitatieDTO(s))
                .ToList();
        }

        // GET (specific) api/<SollicitatieController>/{id}
        [HttpGet("{id}")]
        public SollicitatieDTO Get(int id)
        {
            if (OU.sollicitatie.Find(id) == null)
            {
                SollicitatieDTO sdto = new SollicitatieDTO();
                sdto.Id = -1;
                return sdto;
            }

            SollicitatieDTO s = new SollicitatieDTO(OU.sollicitatie.Include(s => s.Medewerker)
                .Include(s => s.Medewerker.TalentManager)
                .Include(s => s.Vacature)
                .Include(s => s.Vacature.Opdrachtgever)
                .FirstOrDefault(s => s.Id == id));

            return s;
        }

        // ADD api/<SollicitatieController>/add
        [HttpPost("add")]
        public string Add(Sollicitatie_NoId sni)
        {
            Sollicitatie s = new Sollicitatie();

            if (OU.medewerker.Find(sni.MedewerkerId) == null || OU.vacatures.Find(sni.VacatureId) == null)
            {
                return "gefaald";
            }

            s.Medewerker = OU.medewerker.Find(sni.MedewerkerId);
            s.Vacature = OU.vacatures.Find(sni.VacatureId);
            s.Status = 0;
            s.Medewerker_akkoord = false;
            s.Opdrachtgever_akkoord = false;

            OU.Add(s);
            OU.SaveChanges();
            return "gelukt";
        }

        // PUT api/<SollicitatieController>/update
        [HttpPut("update")]
        public string Put(SollicitatieInputDTO s)
        {
            Sollicitatie sou = OU.sollicitatie.Find(s.Id);
            if (sou == null)
            {
                return "gefaald";
            }

            sou.Medewerker = OU.medewerker.Find(s.MedewerkerId);
            sou.Vacature = OU.vacatures.Find(s.VacatureId);
            sou.Status = s.Status;
            sou.Medewerker_akkoord = s.Medewerker_akkoord;
            sou.Opdrachtgever_akkoord = s.Opdrachtgever_akkoord;

            OU.sollicitatie.Update(sou);
            OU.SaveChanges();

            return "gelukt";
        }

        // DELETE api/<SollicitatieController>/delete
        [HttpDelete("delete")]
        public string Delete(int id)
        {
            Sollicitatie s = OU.sollicitatie.Find(id);
            if (s == null)
            {
                return "gefaald";
            }

            OU.sollicitatie.Remove(s);
            OU.SaveChanges();

            return "gelukt";
        }
    }
}
