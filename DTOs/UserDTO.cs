namespace SimpleBlogAPI.DTOs
{
    public class UserDTO
    {
        public string Id { get; set; }
        public string Username { get; set; }
    }

    public class UserForRegistrationDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class UserForLoginDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
