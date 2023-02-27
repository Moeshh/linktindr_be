using dbcontext;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Linktindr_be {
    [Route("api/[controller]")]
    [ApiController]
    public class TalentmanagerController : ControllerBase {

        OurContext OC;

        public TalentmanagerController(OurContext _OC) {
            this.OC = _OC;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<TalentManager> Get() {
            TalentManager t = new TalentManager();
            t.FirstName = "Claudia";
            t.LastName = "Kers";
            t.Email = "Claudia@YoungCapital.com";
            t.Telephone = 0612345678;
            OC.Add(t);
            OC.SaveChanges();
            return OC.talentmanagers;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id) {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value) {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value) {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id) {
        }
    }
}
