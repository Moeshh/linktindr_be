using dbcontext;
using dbcontext.Classes;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Linktindr_be.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class OpdrachtgeverController : ControllerBase {
        OurContext OC;
        public OpdrachtgeverController(OurContext oC) {
            OC = oC;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Opdrachtgever> Get() {
            return OC.Opdrachtgever;
        }

        // GET (specific) api/<OpdrachtgeverController>/{id}
        [HttpGet("{id}")]
        public Opdrachtgever Get(int id) {
            Opdrachtgever t = OC.Opdrachtgever.Find(id);

            return t;
        }

        // ADD api/<OpdrachtgeverController>/add
        [HttpPost("add")]
        public string Add(Opdrachtgever_NoId oni) {
            Opdrachtgever o = new Opdrachtgever();
            o.Name = oni.Name;
            o.Email = oni.Email;
            o.Telephone = oni.Telephone;

            OC.Add(o);
            OC.SaveChanges();
            return "gelukt";
        }

        // PUT api/<OpdrachtgeverController>/update
        [HttpPut("update")]
        public string Put(Opdrachtgever o) {
            Opdrachtgever ooc = OC.Opdrachtgever.Find(o.Id);
            if(ooc == null) {
                return "gefaald";
            }

            ooc.Name = o.Name;
            ooc.Email = o.Email;
            ooc.Telephone = o.Telephone;

            OC.Opdrachtgever.Update(ooc);
            OC.SaveChanges();

            return "gelukt";
        }

        // DELETE api/<OpdrachtgeverController>/delete
        [HttpDelete("delete")]
        public string Delete(int id) {
            Opdrachtgever t = OC.Opdrachtgever.Find(id);
            if(t == null) {
                return "gefaald";
            }

            OC.Opdrachtgever.Remove(t);
            OC.SaveChanges();

            return "gelukt";
        }
    }
}
