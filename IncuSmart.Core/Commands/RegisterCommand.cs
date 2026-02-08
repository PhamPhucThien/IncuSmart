namespace IncuSmart.Core.Commands
{
    public class RegisterCommand
    {

        public string Username { get; set; } = default!;

        public string Password { get; set; } = default!;

        public string FullName { get; set; } = default!;

        public string? Email { get; set; }

        public string Phone { get; set; } = string.Empty;
    }
}
