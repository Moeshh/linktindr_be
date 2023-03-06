using dbcontext;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Linktindr_be {
    [Route("api/[controller]")]
    [ApiController]
    public class SollicitatieController : ControllerBase {

        OurContext OC;

        public SollicitatieController(OurContext _OC) {
            this.OC = _OC;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Sollicitatie> Get()
        {
            return OC.sollicitatie.Select(s => new Sollicitatie
            {
                Id = s.Id,
                Medewerker_Id = s.Medewerker_Id,
                Vacature_Id = s.Vacature_Id,
                Status = s.Status,
                Medewerker_akkoord = s.Medewerker_akkoord,
                Opdrachtgever_akkoord = s.Opdrachtgever_akkoord
            }).ToList();
        }

        [HttpPost("add")]
        public string aanmaken(Sollicitatie_NoId sni)
        {
            Sollicitatie s = new Sollicitatie();

            s.Medewerker_Id = sni.Medewerker_Id;
            s.Vacature_Id = sni.Vacature_Id;
            s.Status = sni.Status;
            s.Medewerker_akkoord = sni.Medewerker_akkoord;
            s.Opdrachtgever_akkoord = sni.Opdrachtgever_akkoord;

            OC.Add(s);
            OC.SaveChanges();
            return "gelukt";
        }
    }
}
