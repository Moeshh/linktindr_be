using dbcontext;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Linktindr_be
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedewerkerController : ControllerBase
    {
        OurContext OU;
        public MedewerkerController(OurContext oU)
        {
            this.OU = oU;
        }

        // GET: api/<MedewerkerController>
        [HttpGet]
        public IEnumerable<Medewerker> Get()
        {
            return OU.medewerker;
        }

        [HttpGet("demomedewerkeraanmaken/{voornaam}")]
        public string aanmaken(string voornaam) { 
            
            Medewerker m = new Medewerker();
            m.Talentmanager_id = 12;
            m.FirstName = voornaam;
            m.LastName = "Fred";
            m.Postcode = "Fred";
            m.Housenumber = "Fred";
            m.Dateofbirth = new DateTime(2008, 5, 1, 8, 30, 52);
            m.Postcode = "Fred";
            m.Housenumber = "Fred";
            m.Email = "Fred";
            m.Telephone = "Fred";
            m.Radius = 12;
            m.Specialization = 3;
            m.Photo = "Fred";
            m.Profiletext = "Fred";
            OU.Add(m);
            OU.SaveChanges();
            return "gelukt";
            }

        // GET api/<MedewerkerController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MedewerkerController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MedewerkerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MedewerkerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
