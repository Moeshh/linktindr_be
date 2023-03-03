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
        public IEnumerable<TalentManager> Get()
        {
            return OC.talentmanager.Select(t => new TalentManager
            {
                Id = t.Id,
                FirstName = t.FirstName,
                LastName = t.LastName,
                Email = t.Email,
                Telephone = t.Telephone
            }).ToList();
        }

        [HttpGet("aanmaken/{voornaam}&{achternaam}&{telefoon}&{email}")]
        public string aanmaken(string voornaam, string achternaam, string telefoon, string email)
        {
            TalentManager t = new TalentManager();
            t.FirstName = voornaam;
            t.LastName = achternaam;
            t.Email = email;
            t.Telephone = telefoon;
            OC.Add(t);
            OC.SaveChanges();
            return "gelukt. " + t.FirstName + " " + t.LastName + " toegevoegd";
        }
    }
}
