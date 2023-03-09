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
        public List<Medewerker> Get()
        {
            return this.OU.medewerker.ToList();
        }

        //GET (maak nieuwe medewerker aan) api/<MedewerkerController>/[Medewerker_NoId]
        [HttpPost("add")]
        public string Aanmaken(Medewerker_NoId mni) { 
            
            Medewerker m = new Medewerker();
            m.IdTalentManager = mni.IdTalentManager;
            m.FirstName = mni.FirstName;
            m.LastName = mni.LastName;
            m.PostCode = mni.PostCode;
            m.HouseNumber = mni.HouseNumber;
            m.DateOfBirth = mni.DateOfBirth;
            m.PostCode = mni.PostCode;
            m.HouseNumber = mni.HouseNumber;
            m.Email = mni.Email;
            m.Telephone = mni.Telephone;
            m.Radius = mni.Radius;
            m.Specialization = mni.Specialization;
            m.Photo = mni.Photo;
            m.ProfileText = mni.ProfileText;
            OU.Add(m);
            OU.SaveChanges();
            return "gelukt";
            }

        //// GET api/<MedewerkerController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}
        //
        //// POST api/<MedewerkerController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}
        //
        //// PUT api/<MedewerkerController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}
        //
        //// DELETE api/<MedewerkerController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
