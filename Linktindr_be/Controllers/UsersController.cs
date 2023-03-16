using dbcontext;
using dbcontext.Classes;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Linktindr_be.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase {

        OurContext OC;
        public UsersController(OurContext oC) {
            OC = oC;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<Users> Get() {
            return OC.users;
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public Users Get(int id) {
            Users u = OC.users.Find(id);

            return u;
        }

        // POST api/<UsersController>
        [HttpPost("add")]
        public string Add(Users_noid uni) {
            Users u = new Users();
            u.email = uni.email;
            u.password = uni.password;
            u.usertype = uni.usertype;
            //OU.Add(u);
            //OU.SaveChanges();
            return "gelukt. Email is: " + u.email + " en password is: " + u.password;
        }

        [HttpPost("check")]
        public string Check([FromBody] Users_barebone uni) {
            Users u = new Users();
            u.email = uni.email;
            u.password = uni.password;
            Users dbu = new Users();
            dbu = OC.users.FirstOrDefault(ocu => ocu.email == u.email);
            string returnmessage = "";
            if(dbu != null) {
                returnmessage += "email is: " + dbu.email;
                if(dbu.password == u.password) {
                    u.usertype = dbu.usertype;
                    returnmessage = " en password is juist en je bent een " + u.usertype;
                } else {
                    returnmessage = " en password is niet juist";
                }
            } else {
                returnmessage += "email bestaat niet";
            }
            
            var json = JsonConvert.SerializeObject(returnmessage, new JsonSerializerSettings {
                StringEscapeHandling = StringEscapeHandling.EscapeNonAscii
            });
            //OU.Add(u);
            //OU.SaveChanges();
            return json;
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value) {
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id) {
        }
    }
}
