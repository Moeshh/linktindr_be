namespace Linktindr_be.Dto
{
    public class LoginResponseDto
    {
        public bool Success { get; set; }

        public string Token { get; set; }

        public LoginResponseDto()
        {
            Success = false;
        }

        public LoginResponseDto(string token)
        {
            this.Success = true;
            this.Token = token;
        }   
    }
}
