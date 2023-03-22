using dbcontext;
using dbcontext.Classes;
using Linktindr_be.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Linktindr_be.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class SollicitatieController : ControllerBase {

        private readonly OurContext OC;

        public SollicitatieController(OurContext OC) {
            this.OC = OC;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<SollicitatieDto> Get() {
            return OC.Sollicitatie.Include(s => s.Medewerker)
                .Include(s => s.Medewerker.TalentManager)
                .Include(s => s.Vacature)
                .Include(s => s.Vacature.Opdrachtgever)
                .Select(s => new SollicitatieDto(s))
                .ToList();
        }

        // GET (specific) api/<SollicitatieController>/{id}
        [HttpGet("{id}")]
        public SollicitatieDto? Get(int id) {
            Sollicitatie? s = OC.Sollicitatie.Include(s => s.Medewerker)
                .Include(s => s.Medewerker.TalentManager)
                .Include(s => s.Vacature)
                .Include(s => s.Vacature.Opdrachtgever)
                .FirstOrDefault(s => s.Id == id);

            if (s == null)
                return null;

            return new SollicitatieDto(s);
        }

        // ADD api/<SollicitatieController>/add
        [HttpPost("add")]
        public bool Add(SaveSollicitatieDto sni) {
            Medewerker? m = OC.Medewerker.Find(sni.MedewerkerId);
            if (m == null)
                return false;

            Vacature? v = OC.Vacatures.Find(sni.VacatureId);
            if (v == null)
                return false;

            Sollicitatie s = new Sollicitatie
            {
                Medewerker = m,
                Vacature = v,
                Status = 0,
                Medewerker_akkoord = false,
                Opdrachtgever_akkoord = false
            };

            OC.Add(s);
            OC.SaveChanges();

            return true;
        }

        // PUT api/<SollicitatieController>/update
        [HttpPut("update/{id:int}")]
        public bool Put(int id, [FromBody] UpdateSollicitatieDto saveDto) {
            Sollicitatie? soc = OC.Sollicitatie.Find(id);
            if(soc == null) {
                return false;
            }

            Medewerker? m = OC.Medewerker.Find(saveDto.MedewerkerId);
            if (m == null)
                return false;

            Vacature? v = OC.Vacatures.Find(saveDto.VacatureId);
            if (v == null)
                return false;

            soc.Medewerker = m;
            soc.Vacature = v;
            soc.Status = Enum.Parse<StatusEnum>(saveDto.Status);
            soc.Medewerker_akkoord = saveDto.Medewerker_akkoord;
            soc.Opdrachtgever_akkoord = saveDto.Opdrachtgever_akkoord;

            OC.Sollicitatie.Update(soc);
            OC.SaveChanges();

            return true;
        }

        // DELETE api/<SollicitatieController>/delete
        [HttpDelete("delete/{id:int}")]
        public bool Delete(int id) {
            Sollicitatie? dbSolliciatie = OC.Sollicitatie.Find(id);
            if(dbSolliciatie == null) {
                return false;
            }

            OC.Sollicitatie.Remove(dbSolliciatie);
            OC.SaveChanges();

            return true;
        }
    }
}
