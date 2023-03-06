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
            return OC.talentmanagers.Select(t => new TalentManager
            {
                Id = t.Id,
                FirstName = t.FirstName,
                LastName = t.LastName,
                Email = t.Email,
                Telephone = t.Telephone
            }).ToList();
        }

        [HttpPost("add")]
        public string aanmaken(TalentManager_NoId tni)
        {
            TalentManager t = new TalentManager();
            t.FirstName = tni.FirstName;
            t.LastName = tni.LastName;
            t.Email = tni.Email;
            t.Telephone = tni.Telephone;
            OC.Add(t);
            OC.SaveChanges();
            return "gelukt";
        }
    }
}
