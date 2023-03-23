using dbcontext;
using dbcontext.Classes;
using Linktindr_be.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Linktindr_be.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController
    {
        private OurContext OC;

        public UserController(OurContext OC)
        {
            this.OC = OC;
        }

        [HttpPost]
        [Route("login")]
        public LoginResponseDto login([FromBody] LoginRequestDto dto)
        {
            // Check medewerker
            Medewerker? m = OC.Medewerker.FirstOrDefault(u => u.Email.Equals(dto.Email) && u.Password.Equals(dto.Password));
            if (m != null) {
                LoginResponseDto LRD = new LoginResponseDto();
                LRD.Success = true;
                LRD.Token = m.Id.ToString();
                LRD.Usertype = "Medewerker";
                return LRD;
            }

            // Check opdrachtgever
            Opdrachtgever? o = OC.Opdrachtgever.FirstOrDefault(u => u.Email.Equals(dto.Email) && u.Password.Equals(dto.Password));
            if(o != null) {
                LoginResponseDto LRD = new LoginResponseDto();
                LRD.Success = true;
                LRD.Token = o.Id.ToString();
                LRD.Usertype = "Opdrachtgever";
                return LRD;
            }

            // Check talentmanager
            TalentManager? t = OC.TalentManager.FirstOrDefault(u => u.Email.Equals(dto.Email) && u.Password.Equals(dto.Password));
            if(t != null) {
                LoginResponseDto LRD = new LoginResponseDto();
                LRD.Success = true;
                LRD.Token = t.Id.ToString();
                LRD.Usertype = "Talentmanager";
                return LRD;
            }

            return new LoginResponseDto();
        }

    }
}
