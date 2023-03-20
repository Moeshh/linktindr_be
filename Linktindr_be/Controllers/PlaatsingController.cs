using dbcontext;
using dbcontext.Classes;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Linktindr_be.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class PlaatsingController : ControllerBase {
        OurContext OC;
        public PlaatsingController(OurContext oC) {
            OC = oC;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Plaatsing> Get() {
            return OC.Plaatsing;
        }

        // GET (specific) api/<PlaatsingController>/{id}
        [HttpGet("{id}")]
        public Plaatsing Get(int id) {
            Plaatsing p = OC.Plaatsing.Find(id);

            return p;
        }

        // ADD api/<PlaatsingController>/add
        [HttpPost("add")]
        public string Add(Plaatsing_NoId pni) {
            Plaatsing p = new Plaatsing();
            p.Sollicitatie_id = pni.Sollicitatie_id;

            OC.Add(p);
            OC.SaveChanges();
            return "gelukt";
        }

        // PUT api/<PlaatsingController>/update
        [HttpPut("update")]
        public string Put(Plaatsing p) {
            Plaatsing poc = OC.Plaatsing.Find(p.Id);
            if(poc == null) {
                return "gefaald";
            }

            poc.Sollicitatie_id = p.Sollicitatie_id;

            OC.Plaatsing.Update(poc);
            OC.SaveChanges();

            return "gelukt";
        }

        // DELETE api/<PlaatsingController>/delete
        [HttpDelete("delete")]
        public string Delete(int id) {
            Plaatsing p = OC.Plaatsing.Find(id);
            if(p == null) {
                return "gefaald";
            }

            OC.Plaatsing.Remove(p);
            OC.SaveChanges();

            return "gelukt";
        }
    }
}
