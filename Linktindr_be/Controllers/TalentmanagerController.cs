using dbcontext;
using dbcontext.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Linktindr_be.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class TalentmanagerController : ControllerBase {
        OurContext OC;
        public TalentmanagerController(OurContext oC) {
            OC = oC;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public List<TalentManager> Get() {
            
            List<TalentManager> tcsv = System.IO.File.ReadAllLines("C:\\Users\\vivo-\\source\\repos\\Linktindr_be\\Linktindr_be\\dataSet_linktindr_werknemer.csv")
                .Skip(1)
                .Select(v => TalentManagerDTO.FromCsv(v))
                .ToList();

            
            foreach(TalentManager tm in tcsv) {
                OC.Add(tm);
                OC.SaveChanges();
            }

            return tcsv;
        }

        // GET (specific) api/<TalentmanagerController>/{id}
        [HttpGet("{id}")]
        public TalentManagerDTO Get(int id) {
            if(OC.Talentmanager.Find(id) == null) {
                TalentManagerDTO tdto = new TalentManagerDTO();
                tdto.Id = -1;
                tdto.FirstName = "Invalid";
                tdto.LastName = "ID";
                return tdto;
            }

            TalentManagerDTO t = new TalentManagerDTO(OC.Talentmanager.Find(id));

            return t;
        }

        // ADD api/<TalentmanagerController>/add
        [HttpPost("add")]
        public string Add(TalentManager_NoId tni) {
            TalentManager t = new TalentManager();
            t.FirstName = tni.FirstName;
            t.LastName = tni.LastName;
            t.Email = tni.Email;
            t.Telephone = tni.Telephone;
            OC.Add(t);
            OC.SaveChanges();

            return "gelukt";
        }

        // PUT api/<TalentmanagerController>/update
        [HttpPut("update")]
        public string Put(TalentManagerDTO t) {
            TalentManager toc = OC.Talentmanager.Find(t.Id);
            if(toc == null) {
                return "gefaald";
            }

            toc.FirstName = t.FirstName;
            toc.LastName = t.LastName;
            toc.Email = t.Email;
            toc.Telephone = t.Telephone;

            OC.Talentmanager.Update(toc);
            OC.SaveChanges();

            return "gelukt";
        }

        // DELETE api/<TalentManagerController>/delete
        [HttpDelete("delete")]
        public string Delete(int id) {
            TalentManager t = OC.Talentmanager.Find(id);
            if(t == null) {
                return "gefaald";
            }

            OC.Talentmanager.Remove(t);
            OC.SaveChanges();

            return "gelukt";
        }
    }
}
