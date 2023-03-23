using dbcontext;
using dbcontext.Classes;
using Linktindr_be.Dto;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Linktindr_be.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class OpdrachtgeverController : BaseController {
        
        public OpdrachtgeverController(OurContext OC) : base(OC)
        {
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Opdrachtgever> Get() {
            return OC.Opdrachtgever;
        }

        // GET (specific) api/<OpdrachtgeverController>/{id}
        [HttpGet("{id}")]
        public Opdrachtgever? Get(int id) {
            return OC.Opdrachtgever.Find(id);
        }

        // ADD api/<OpdrachtgeverController>/add
        [HttpPost("add")]
        public bool Add(SaveOpdrachtgeverDto oni) {
            Opdrachtgever o = new Opdrachtgever();
            o.Name = oni.Name;
            o.Email = oni.Email;
            o.Password = oni.Password;
            o.Telephone = oni.Telephone;

            OC.Add(o);
            OC.SaveChanges();

            return true;
        }

        // PUT api/<OpdrachtgeverController>/update
        [HttpPut("update/{id:int}")]
        public bool Put(int id, SaveOpdrachtgeverDto o) {
            Opdrachtgever? ooc = OC.Opdrachtgever.Find(id);
            if(ooc == null) {
                return false;
            }

            ooc.Name = o.Name;
            ooc.Email = o.Email;
            ooc.Telephone = o.Telephone;

            OC.Opdrachtgever.Update(ooc);
            OC.SaveChanges();

            return true;
        }

        // DELETE api/<OpdrachtgeverController>/delete
        [HttpDelete("delete/{id:int}")]
        public bool Delete(int id) {
            Opdrachtgever? dbOpdrachtgever = OC.Opdrachtgever.Find(id);
            if(dbOpdrachtgever == null) {
                return false;
            }

            OC.Opdrachtgever.Remove(dbOpdrachtgever);
            OC.SaveChanges();

            return true;
        }
    }
}
