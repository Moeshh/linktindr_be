using dbcontext.Classes;

namespace Linktindr_be.Dto
{
    public class LoginResponseDto
    {
        public bool Success { get; set; }

        public string Token { get; set; }
        public string Usertype { get; set; }

        public int UserId { get; set; }

        public LoginResponseDto()
        {
            Success = false;
        }

        public LoginResponseDto(User user)
        {
            this.Success = true;
            this.Token = user.Token;
            this.UserId = user.Id;
            this.Usertype = user.GetUserType().ToString();
        }   
    }
}
