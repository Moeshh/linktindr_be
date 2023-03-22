using dbcontext;
using dbcontext.Classes;
using Linktindr_be.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Linktindr_be.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class TalentmanagerController : ControllerBase {
        
        private readonly OurContext OC;

        public TalentmanagerController(OurContext OC) {
            this.OC = OC;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<TalentManager> Get() {
            return OC.TalentManager.ToList();
        }

        // GET (specific) api/<TalentmanagerController>/{id}
        [HttpGet("{id:int}")]
        public TalentManagerDto? Get(int id) {
            TalentManager? t = OC.TalentManager.Find(id);
            if (t == null)
                return null;

            return new TalentManagerDto(t);
        }

        // ADD api/<TalentmanagerController>/add
        [HttpPost("add")]
        public bool Add(SaveTalentmanagerDto tni) {
            TalentManager t = new TalentManager();
            t.Name = tni.Name;
            t.Email = tni.Email;
            t.Password = tni.Password;
            t.Telephone = tni.Telephone;

            OC.Add(t);
            OC.SaveChanges();

            return true;
        }

        // PUT api/<TalentmanagerController>/update
        [HttpPut("update/{id:int}")]
        public bool Put(int id, [FromBody] SaveTalentmanagerDto t)
        {
            TalentManager? dbTalentManager = OC.TalentManager.Find(id);
            if(dbTalentManager == null) {
                return false;
            }

            dbTalentManager.Name = t.Name;
            dbTalentManager.Email = t.Email;
            dbTalentManager.Telephone = t.Telephone;
            dbTalentManager.Password = t.Password;

            OC.TalentManager.Update(dbTalentManager);
            OC.SaveChanges();

            return true;
        }

        // DELETE api/<TalentManagerController>/delete
        [HttpDelete("delete/{id:int}")]
        public bool Delete(int id) {
            TalentManager? dbTalentManager = OC.TalentManager.Find(id);
            if(dbTalentManager == null) {
                return false;
            }

            OC.TalentManager.Remove(dbTalentManager);
            OC.SaveChanges();

            return true;
        }
    }
}
