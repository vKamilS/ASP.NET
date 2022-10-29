namespace Web.Dto
{
    public class UserRegisterDto
    {
        public string UserName { get; set; }
        public string? AvatarLink { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Created { get; set; }
    }
}
