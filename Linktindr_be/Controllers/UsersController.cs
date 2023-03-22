using dbcontext;
using dbcontext.Classes;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Drawing;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Linktindr_be.Controllers {
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
            return OC.Users;
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public UsersDTO Get(int id) {
            Users u = OC.Users.Find(id);
            if(u == null) {
                return null;
            }

            return new UsersDTO(u);
        }

        // POST api/<UsersController>
        [HttpPost("add")]
        public string Add(Users_noid uni) {
            Users u = new Users();
            u.Email = uni.Email;
            u.Password = uni.Password;
            u.Usertype = uni.Usertype;
            //OU.Add(u);
            //OU.SaveChanges();
            return "gelukt. Email is: " + u.Email + " en Password is: " + u.Password;
        }

        [HttpPost("check")]
        public string Check([FromBody] Users_noid uni) {
            Users u = new Users();
            u.Email = uni.Email;
            u.Password = uni.Password;
            u.Usertype = uni.Usertype;

            Users ocu = new Users();
            ocu = OC.Users.Single(s => s.Email == uni.Email);

            string returnmessage = "";
            if(ocu.Password == u.Password) {
                returnmessage = "Password is juist";
            } else {
                returnmessage = "Password is niet juist";
            }

            var data = new {
                Id = ocu.Id,
                Email = ocu.Email,
                Usertype = ocu.Usertype.ToString(),
                sentData = u,
                newData = ocu,
                Message = returnmessage
            };
            var json = JsonConvert.SerializeObject(data, new JsonSerializerSettings {
                StringEscapeHandling = StringEscapeHandling.EscapeNonAscii
            });
            return json;
        }

        [HttpPost("add_user_talentmanager")]
        public string Check([FromBody] CreateNewUserDTO utm) {
            Users u = new Users();
            TalentManager t = new TalentManager();

            u.Email = utm.Email;
            u.Password = utm.Password;
            //string enumvalue = utm.User.Usertype.ToString();
            //u.Usertype = (UsertypeEnum)Enum.Parse(typeof(UsertypeEnum), utm.Usertype);
            //u.Usertype = utm.Usertype;

            t.FirstName = utm.FirstName;
            t.LastName = utm.LastName;
            t.Email = utm.Email;
            t.Telephone = (int)utm.Telephone;

            var data = new {
                sentData = utm,
                userData = u,
                tmData = t
            };
            /*
            string[] returnmessage = new string[3];
            int[] errors = new int[3];
            Users u = new Users();
            TalentManager t = new TalentManager();
            Users ocu = new Users();
            ocu = OC.Users.Single(s => s.Email == utm.Email);
            bool canAdd = false;
            if (ocu != null) {
                returnmessage[0] = "Email found; ";
                if(ocu.Usertype.ToString() == utm.Usertype) {
                    returnmessage[0] += "Usertype already exists; ";
                    errors[0] = errors[1] = 1;
                } else {
                    canAdd = true;
                }
            } else {
                returnmessage[0] = "new user; ";
                canAdd = true;
            }
            if(canAdd) {
                u.Email = utm.Email;
                u.Password = utm.Password;
                //string enumvalue = utm.User.Usertype.ToString();
                u.Usertype = (UsertypeEnum)Enum.Parse(typeof(UsertypeEnum), utm.Usertype);
                //u.Usertype = utm.Usertype;

                t.FirstName = utm.FirstName;
                t.LastName = utm.LastName;
                t.Email = utm.Email;
                t.Telephone = utm.Telephone;
            }
            var data = new {
                sentData = utm,
                userData = u,
                tmData = t,
                Messages = returnmessage,
                Errors = errors
            };

            //OC.Add(v);
            //OC.SaveChanges();
            */
            var json = JsonConvert.SerializeObject(data, new JsonSerializerSettings {
                StringEscapeHandling = StringEscapeHandling.EscapeNonAscii
            });
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
