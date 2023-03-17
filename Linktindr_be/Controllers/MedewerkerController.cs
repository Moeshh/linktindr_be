﻿using dbcontext;
using dbcontext.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Linktindr_be.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedewerkerController : ControllerBase
    {
        OurContext OU;
        public MedewerkerController(OurContext oU)
        {
            OU = oU;
        }

        // GET: api/<MedewerkerController>
        [HttpGet]
        public List<MedewerkerDTO> Get()
        {
            return OU.medewerker.Include(m => m.TalentManager)
                .Select(m => new MedewerkerDTO(m))
                .ToList();
        }

        // GET (specific) api/<MedewerkerController>/{id}
        [HttpGet("{id}")]
        public MedewerkerDTO Get(int id)
        {
            if (OU.medewerker.Find(id) == null)
            {
                MedewerkerDTO mdto = new MedewerkerDTO();
                mdto.Id = -1;
                mdto.FirstName = "Invalid";
                mdto.LastName = "ID";
                return mdto;
            }

            MedewerkerDTO m = new MedewerkerDTO(OU.medewerker.Include(m => m.TalentManager)
                .FirstOrDefault(m => m.Id == id));

            return m;
        }

        //GET (maak nieuwe medewerker aan) api/<MedewerkerController>/add
        [HttpPost("add")]
        public string Add(Medewerker_NoId mni)
        {
            Medewerker m = new Medewerker();

            m.TalentManager = OU.talentmanager.Find(mni.TalentManagerId);
            m.FirstName = mni.FirstName;
            m.LastName = mni.LastName;
            m.PostCode = mni.PostCode;
            m.HouseNumber = mni.HouseNumber;
            m.DateOfBirth = mni.DateOfBirth;
            m.PostCode = mni.PostCode;
            m.HouseNumber = mni.HouseNumber;
            m.Email = mni.Email;
            m.Telephone = mni.Telephone;
            m.Radius = mni.Radius;
            m.Uitstroomrichting = mni.Uitstroomrichting;
            m.Photo = mni.Photo;
            m.ProfileText = mni.ProfileText;

            OU.Add(m);
            OU.SaveChanges();
            return "gelukt";
        }

        // PUT api/<MedewerkerController>/update
        [HttpPut("update")]
        public string Put(MedewerkerInputDTO m)
        {
            Medewerker mou = OU.medewerker.Find(m.Id);
            if (mou == null)
            {
                return "gefaald";
            }

            TalentManager t = OU.talentmanager.Find(m.TalentManagerId);

            mou.TalentManager = t;
            mou.FirstName = m.FirstName;
            mou.LastName = m.LastName;
            mou.PostCode = m.PostCode;
            mou.HouseNumber = m.HouseNumber;
            mou.DateOfBirth = m.DateOfBirth;
            mou.PostCode = m.PostCode;
            mou.HouseNumber = m.HouseNumber;
            mou.Email = m.Email;
            mou.Telephone = m.Telephone;
            mou.Radius = m.Radius;
            mou.Uitstroomrichting = m.Uitstroomrichting;
            mou.Photo = m.Photo;
            mou.ProfileText = m.ProfileText;

            OU.medewerker.Update(mou);
            OU.SaveChanges();

            return "gelukt";
        }

        // DELETE api/<MedewerkerController>/delete
        [HttpDelete("delete")]
        public string Delete(int id)
        {
            Medewerker m = OU.medewerker.Find(id);
            if (m == null)
            {
                return "gefaald";
            }

            OU.medewerker.Remove(m);
            OU.SaveChanges();

            return "gelukt";
        }
    }
}
