namespace Application.Dto.Security
{
    public class LoginResponseDto
    {
        public string Token { get; set; }
        public bool ConfirmedEmail { get; set; }
        public UserDto User { get; set; }
    }
}