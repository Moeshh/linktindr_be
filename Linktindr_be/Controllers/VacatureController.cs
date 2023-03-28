using dbcontext;
using dbcontext.Classes;
using Linktindr_be.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Linktindr_be.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class VacatureController : BaseController {

        public VacatureController(OurContext OC) : base(OC)
        {
        }

        // GET: api/<VacatureController>
        [HttpGet]
        public IEnumerable<VacatureDto> Get() {
            return OC.Vacature.Include(v => v.Opdrachtgever)
                .Select(v => new VacatureDto(v))
                .ToList();
        }

        // GET (specific) api/<VacatureController>/{id}
        [HttpGet("{id}")]
        public VacatureDto? Get(int id) {
            Vacature? v = OC.Vacature.Include(m => m.Opdrachtgever).FirstOrDefault(v => v.Id == id);
            if (v == null)
                return null;

            return new VacatureDto(v);
        }

        // GET (specific) api/<VacatureController>/opdrachtgever/{id}
        [HttpGet("opdrachtgever/{id}")]
        public IEnumerable<VacatureDto> GetByOpdrachtgever(int id) {
            return OC.Vacature.Include(v => v.Opdrachtgever)
                .Where(v => v.Opdrachtgever.Id == id)
                .Select(v => new VacatureDto(v))
                .ToList();
        }

        // ADD api/<VacatureController>/add
        [HttpPost("add")]
        public bool Add([FromBody] SaveVacatureDto vni)
        {
            Opdrachtgever? o = OC.Opdrachtgever.Find(vni.OpdrachtgeverId);
            if (o == null)
                return false;

            Vacature v = new Vacature();
            v.Opdrachtgever = o;
            v.Title = vni.Title;
            v.Description = vni.Description;
            v.Uitstroomrichting = Enum.Parse<Specialization>(vni.Uitstroomrichting);
            v.Location = vni.Location;
            v.Startdate = vni.Startdate;
            v.Enddate = vni.Enddate;

            OC.Add(v);
            OC.SaveChanges();
            return true;
        }

        // PUT api/<VacatureController>/update
        [HttpPut("update/{id:int}")]
        public bool Put(int id, [FromBody] SaveVacatureDto v) {
            Vacature? voc = OC.Vacature.Find(id);
            if(voc == null) {
                return false;
            }

            Opdrachtgever? o = OC.Opdrachtgever.Find(v.OpdrachtgeverId);
            if (o == null)
            {
                return false;
            }

            voc.Opdrachtgever = o;
            voc.Title = v.Title;
            voc.Description = v.Description;
            voc.Uitstroomrichting = Enum.Parse<Specialization>(v.Uitstroomrichting);
            voc.Location = v.Location;
            voc.Startdate = v.Startdate;
            voc.Enddate = v.Enddate;

            OC.Vacature.Update(voc);
            OC.SaveChanges();

            return true;
        }

        // DELETE api/<VacatureController>/delete
        [HttpDelete("delete")]
        public bool Delete(int id) {
            Vacature? v = OC.Vacature.Find(id);
            if(v == null) {
                return false;
            }

            OC.Vacature.Remove(v);
            OC.SaveChanges();

            return true;
        }
    }
}
