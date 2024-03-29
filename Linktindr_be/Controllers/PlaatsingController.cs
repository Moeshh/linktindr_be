﻿using dbcontext;
using dbcontext.Classes;
using Linktindr_be.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Linktindr_be.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class PlaatsingController : BaseController {
        
        public PlaatsingController(OurContext OC) : base(OC)
        {
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Plaatsing> Get() {
            return OC.Plaatsing.ToList();
        }

        // GET (specific) api/<PlaatsingController>/{id}
        [HttpGet("{id}")]
        public Plaatsing? Get(int id) {
            return OC.Plaatsing.Find(id);
        }

        // GET (specific) api/<PlaatsingController>/talentmanager/{id}
        [HttpGet("talentmanager/{id}")]
        public IEnumerable<PlaatsingDto> GetByTalentmanager(int id) {
            return OC.Plaatsing.Include(s => s.Sollicitatie)
                .Include(s => s.Sollicitatie.Medewerker)
                .Include(s => s.Sollicitatie.Medewerker.TalentManager)
                .Where(s => s.Sollicitatie.Medewerker.TalentManager.Id == id)
                .Include(s => s.Sollicitatie.Vacature)
                .Include(s => s.Sollicitatie.Vacature.Opdrachtgever)
                .Select(s => new PlaatsingDto(s))
                .ToList();
        }

        // ADD api/<PlaatsingController>/add
        [HttpPost("add")]
        public bool Add(SavePlaatsingDto saveDto) {
            Sollicitatie? s = OC.Sollicitatie.Find(saveDto.SollicitatieId);
            if (s == null)
                return false;

            Medewerker? m = OC.Medewerker.Find(saveDto.MedewerkerId);
            if (m == null)
                return false;

            Plaatsing p = new Plaatsing();
            p.Sollicitatie = s;
            p.StartDate = saveDto.StartDate;
            p.EndDate = saveDto.EndDate;
            p.Active = saveDto.Active;

            OC.Add(p);
            OC.SaveChanges();
            return true;
        }

        // PUT api/<PlaatsingController>/update
        [HttpPut("update/{id:int}")]
        public bool Put(int id, [FromBody] SavePlaatsingDto saveDto) {
            Plaatsing poc = OC.Plaatsing.Find(id);
            if( poc == null) {
                return false;
            }

            Sollicitatie? s = OC.Sollicitatie.Find(saveDto.SollicitatieId);
            if (s == null)
                return false;

            Medewerker? m = OC.Medewerker.Find(saveDto.MedewerkerId);
            if (m == null)
                return false;

            poc.Active = saveDto.Active;

            OC.Plaatsing.Update(poc);
            OC.SaveChanges();

            return true;
        }

        // DELETE api/<PlaatsingController>/delete
        [HttpDelete("delete")]
        public bool Delete(int id) {
            Plaatsing? p = OC.Plaatsing.Find(id);
            if(p == null) {
                return false;
            }

            OC.Plaatsing.Remove(p);
            OC.SaveChanges();

            return true;
        }
    }
}
