using dbcontext;
using dbcontext.Classes;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Linktindr_be.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaatsingController : ControllerBase
    {
        OurContext OU;
        public PlaatsingController(OurContext oU)
        {
            OU = oU;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Plaatsing> Get()
        {
            return OU.plaatsing;
        }

        // GET (specific) api/<PlaatsingController>/{id}
        [HttpGet("{id}")]
        public Plaatsing Get(int id)
        {
            Plaatsing p = OU.plaatsing.Find(id);

            return p;
        }

        // ADD api/<PlaatsingController>/add
        [HttpPost("add")]
        public string Add(Plaatsing_NoId pni)
        {
            Plaatsing p = new Plaatsing();
            p.Sollicitatie_id = pni.Sollicitatie_id;

            OU.Add(p);
            OU.SaveChanges();
            return "gelukt";
        }

        // PUT api/<PlaatsingController>/update
        [HttpPut("update")]
        public string Put(Plaatsing p)
        {
            Plaatsing pou = OU.plaatsing.Find(p.Id);
            if (pou == null)
            {
                return "gefaald";
            }

            pou.Sollicitatie_id = p.Sollicitatie_id;

            OU.plaatsing.Update(pou);
            OU.SaveChanges();

            return "gelukt";
        }

        // DELETE api/<PlaatsingController>/delete
        [HttpDelete("delete")]
        public string Delete(int id)
        {
            Plaatsing p = OU.plaatsing.Find(id);
            if (p == null)
            {
                return "gefaald";
            }

            OU.plaatsing.Remove(p);
            OU.SaveChanges();

            return "gelukt";
        }
    }
}
