using dbcontext;
using Microsoft.AspNetCore.Mvc;

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
        public IEnumerable<Sollicitatie> Get()
        {
            return OU.sollicitatie;
        }

        // GET (specific) api/<SollicitatieController>/{id}
        [HttpGet("{id}")]
        public Sollicitatie Get(int id)
        {
            Sollicitatie s = OU.sollicitatie.Find(id);

            return s;
        }

        // ADD api/<SollicitatieController>/add
        [HttpPost("add")]
        public string Add(Sollicitatie_NoId sni)
        {
            Sollicitatie s = new Sollicitatie();

            //s.Medewerker_Id = sni.Medewerker_Id;
            //s.Vacature_Id = sni.Vacature_Id;
            s.Status = sni.Status;
            s.Medewerker_akkoord = sni.Medewerker_akkoord;
            s.Opdrachtgever_akkoord = sni.Opdrachtgever_akkoord;

            OU.Add(s);
            OU.SaveChanges();
            return "gelukt";
        }

        // PUT api/<SollicitatieController>/update
        [HttpPut("update")]
        public string Put(Sollicitatie s)
        {
            Sollicitatie sou = OU.sollicitatie.Find(s.Id);
            if (sou == null)
            {
                return "gefaald";
            }

            //sou.Medewerker_Id = s.Medewerker_Id;
            //sou.Vacature_Id = s.Vacature_Id;
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
