using dbcontext;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Linktindr_be
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacatureController : ControllerBase
    {
        OurContext OU;
        public VacatureController(OurContext oU)
        {
            this.OU = oU;
        }

        // GET: api/<VacatureController>
        [HttpGet]
        public IEnumerable<Vacature> Get()
        {
            return OU.vacature;
        }

        [HttpPost("add")]
        public string Aanmaken(Vacature_NoId vni)
        {
            Vacature v = new Vacature();
            v.Opdrachtgever_id = vni.Opdrachtgever_id;
            v.Title = vni.Title;
            v.Description = vni.Description;
            v.Uitstroomrichting = vni.Uitstroomrichting;
            v.Location = vni.Location;
            v.Startdate = vni.Startdate;
            v.Einddate = vni.Einddate;

            OU.Add(v);
            OU.SaveChanges();
            return "gelukt";
        }

        //// GET api/<VacatureController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}
        //
        //// POST api/<VacatureController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}
        //
        //// PUT api/<VacatureController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}
        //
        //// DELETE api/<VacatureController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
