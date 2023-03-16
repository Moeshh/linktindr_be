using dbcontext;
using dbcontext.Classes;
using Linktindr_be.Dto;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Linktindr_be.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TalentmanagerController : ControllerBase
    {
        OurContext OU;
        public TalentmanagerController(OurContext oU)
        {
            OU = oU;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<TalentManager> Get()
        {
            return OU.talentmanager;
        }

        // GET (specific) api/<TalentmanagerController>/{id}
        [HttpGet("{id}")]
        public TalentManager Get(int id)
        {
            TalentManager t = OU.talentmanager.Find(id);

            return t;
        }

        // ADD api/<TalentmanagerController>/add
        [HttpPost("add")]
        public string Add(TalentManager_NoId tni)
        {
            TalentManager t = new TalentManager();
            t.FirstName = tni.FirstName;
            t.LastName = tni.LastName;
            t.Email = tni.Email;
            t.Telephone = tni.Telephone;
            OU.Add(t);
            OU.SaveChanges();
            return "gelukt";
        }

        // PUT api/<TalentmanagerController>/update
        [HttpPut("update")]
        public string Put(SaveTalentmanagerDto t)
        {
            TalentManager tou = OU.talentmanager.Find(t.Id);
            if (tou == null)
            {
                return "gefaald";
            }

            tou.FirstName = t.FirstName;
            tou.LastName = t.LastName;
            tou.Email = t.Email;
            tou.Telephone = t.Telephone;

            OU.talentmanager.Update(tou);
            OU.SaveChanges();

            return "gelukt";
        }

        // DELETE api/<TalentManagerController>/delete
        [HttpDelete("delete")]
        public string Delete(int id)
        {
            TalentManager t = OU.talentmanager.Find(id);
            if (t == null)
            {
                return "gefaald";
            }

            OU.talentmanager.Remove(t);
            OU.SaveChanges();

            return "gelukt";
        }
    }
}
