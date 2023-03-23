using dbcontext;
using dbcontext.Classes;
using Linktindr_be.Dto;
using Linktindr_be.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Linktindr_be.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly OurContext OC;

        public UserController(OurContext OC)
        {
            this.OC = OC;
        }

        [HttpGet]
        public User loggedInUser()
        {
            bool hasAuthorization = HttpContext.Items.ContainsKey("User");
            if (hasAuthorization)
            {
                User? u = (User)HttpContext.Items["User"];
                return u;
            }

            return null;
        }

        [HttpPost]
        [Route("login")]
        public LoginResponseDto login([FromBody] LoginRequestDto dto)
        {
            // Check medewerker
            Medewerker? m = OC.Medewerker.FirstOrDefault(u => u.Email.Equals(dto.Email) && u.Password.Equals(dto.Password));
            if (m != null) {
                m.Token = StringUtils.RandomToken();
                OC.Medewerker.Update(m);
                OC.SaveChanges();

                LoginResponseDto LRD = new LoginResponseDto();
                LRD.Success = true;
                LRD.Token = m.Token;
                LRD.Usertype = "Medewerker";
                return LRD;
            }

            // Check opdrachtgever
            Opdrachtgever? o = OC.Opdrachtgever.FirstOrDefault(u => u.Email.Equals(dto.Email) && u.Password.Equals(dto.Password));
            if(o != null) {
                o.Token = StringUtils.RandomToken();
                OC.Opdrachtgever.Update(o);
                OC.SaveChanges();

                LoginResponseDto LRD = new LoginResponseDto();
                LRD.Success = true;
                LRD.Token = o.Token;
                LRD.Usertype = "Opdrachtgever";
                return LRD;
            }

            // Check talentmanager
            TalentManager? t = OC.TalentManager.FirstOrDefault(u => u.Email.Equals(dto.Email) && u.Password.Equals(dto.Password));
            if(t != null) {
                t.Token = StringUtils.RandomToken();
                OC.TalentManager.Update(t);
                OC.SaveChanges();

                LoginResponseDto LRD = new LoginResponseDto();
                LRD.Success = true;
                LRD.Token = t.Token;
                LRD.Usertype = "Talentmanager";
                return LRD;
            }

            return new LoginResponseDto();
        }

        [HttpDelete]
        [Route("revoke")]
        public void deleteToken()
        {
            // 
        }

    }
}
