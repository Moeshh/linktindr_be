using dbcontext;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Linktindr_be.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TalentmanagerController : ControllerBase
    {

        OurContext OC;

        public TalentmanagerController(OurContext _OC)
        {
            OC = _OC;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<TalentManager> Get()
        {
            return OC.talentmanager.Select(t => new TalentManager {
                Id = t.Id,
                Firstname = t.Firstname,
                Lastname = t.Lastname,
                Email = t.Email,
                Telephone = t.Telephone
            }).ToList();
        }
        [HttpGet("aanmaken/{voornaam}&{achternaam}&{telefoon}&{email}")]
        public string aanmaken(string voornaam, string achternaam, string telefoon, string email)
        {
            TalentManager t = new TalentManager();
            t.Firstname = voornaam;
            t.Lastname = achternaam;
            t.Email = email;
            t.Telephone = telefoon;
            OC.Add(t);
            OC.SaveChanges();
            return "gelukt. " + t.Firstname + " " + t.Lastname + " toegevoegd";
        }
    }
}
