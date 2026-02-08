namespace IncuSmart.API.Requests
{
    public class LoginRequest
    {
        [NotNull]
        [MinLength(8, ErrorMessage = "Username must be at least 8 characters long")]
        [MaxLength(15, ErrorMessage = "Username must be at most 15 characters long")]
        public string Username { get; set; } = default!;
        [NotNull]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]
        [MaxLength(20, ErrorMessage = "Password must be at most 20 characters long")]
        public string Password { get; set; } = default!;
    }
}
