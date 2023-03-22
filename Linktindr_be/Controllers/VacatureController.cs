using dbcontext;
using dbcontext.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Linktindr_be.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class VacatureController : ControllerBase {
        OurContext OC;
        public VacatureController(OurContext oC) {
            OC = oC;
        }

        // GET: api/<VacatureController>
        [HttpGet]
        public IEnumerable<VacaturesDTO> Get() {
            return OC.Vacatures.Include(v => v.Opdrachtgever)
                .Select(v => new VacaturesDTO(v))
                .ToList();
        }

        // GET (specific) api/<VacatureController>/{id}
        [HttpGet("{id}")]
        public VacaturesDTO? Get(int id) {
            if(OC.Vacatures.Find(id) == null) {
                VacaturesDTO vdto = new VacaturesDTO();
                vdto.Id = -1;
                vdto.Title = "Invalid";
                vdto.Description = "ID";
                return vdto;
            }

            Vacatures? v = OC.Vacatures.Include(v => v.Opdrachtgever).FirstOrDefault(v => v.Id == id);
            if (v == null)
                return null;

            return new VacaturesDTO(v);
        }

        // ADD api/<VacatureController>/add
        [HttpPost("add")]
        public string Add(Vacatures_NoId vni) {
            Opdrachtgever? o = OC.Opdrachtgever.Find(vni.OpdrachtgeverId);
            if (o == null)
                return "failed";

            Vacatures v = new Vacatures();
            v.Opdrachtgever = o;
            v.Title = vni.Title;
            v.Description = vni.Description;
            v.Uitstroomrichting = vni.Uitstroomrichting;
            v.Location = vni.Location;
            v.Startdate = vni.Startdate;
            v.Enddate = vni.Enddate;

            OC.Add(v);
            OC.SaveChanges();
            return "gelukt";
        }

        // PUT api/<VacatureController>/update
        [HttpPut("update")]
        public string Put(VacaturesInputDTO v) {
            Vacatures? voc = OC.Vacatures.Find(v.Id);
            if(voc == null) {
                return "gefaald";
            }

            Opdrachtgever? o = OC.Opdrachtgever.Find(v.OpdrachtgeverId);
            if (o == null)
            {
                return "gefaald";
            }

            voc.Opdrachtgever = o;
            voc.Title = v.Title;
            voc.Description = v.Description;
            voc.Uitstroomrichting = v.Uitstroomrichting;
            voc.Location = v.Location;
            voc.Startdate = v.Startdate;
            voc.Enddate = v.Enddate;

            OC.Vacatures.Update(voc);
            OC.SaveChanges();

            return "gelukt";
        }

        // DELETE api/<VacatureController>/delete
        [HttpDelete("delete")]
        public string Delete(int id) {
            Vacatures? v = OC.Vacatures.Find(id);
            if(v == null) {
                return "gefaald";
            }

            OC.Vacatures.Remove(v);
            OC.SaveChanges();

            return "gelukt";
        }
    }
}
