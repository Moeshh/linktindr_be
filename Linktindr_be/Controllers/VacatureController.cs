using dbcontext;
using dbcontext.Classes;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Linktindr_be.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacatureController : ControllerBase
    {
        OurContext OU;
        public VacatureController(OurContext oU)
        {
            OU = oU;
        }

        // GET: api/<VacatureController>
        [HttpGet]
        public IEnumerable<Vacature> Get()
        {
            return OU.vacature;
        }

        // GET (specific) api/<VacatureController>/{id}
        [HttpGet("{id}")]
        public Vacature Get(int id)
        {
            Vacature v = OU.vacature.Find(id);

            return v;
        }

        // ADD api/<VacatureController>/add
        [HttpPost("add")]
        public string Add(Vacature_NoId vni)
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

        // PUT api/<VacatureController>/update
        [HttpPut("update")]
        public string Put(Vacature v)
        {
            Vacature vou = OU.vacature.Find(v.Id);
            if (vou == null)
            {
                return "gefaald";
            }

            vou.Opdrachtgever_id = v.Opdrachtgever_id;
            vou.Title = v.Title;
            vou.Description = v.Description;
            vou.Uitstroomrichting = v.Uitstroomrichting;
            vou.Location = v.Location;
            vou.Startdate = v.Startdate;
            vou.Einddate = v.Einddate;

            OU.vacature.Update(vou);
            OU.SaveChanges();

            return "gelukt";
        }

        // DELETE api/<VacatureController>/delete
        [HttpDelete("delete")]
        public string Delete(int id)
        {
            Vacature v = OU.vacature.Find(id);
            if (v == null)
            {
                return "gefaald";
            }

            OU.vacature.Remove(v);
            OU.SaveChanges();

            return "gelukt";
        }
    }
}
