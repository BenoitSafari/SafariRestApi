namespace SafariRest.Services;

public static class AuthenticationUtils
{
    public enum EUserType
    {
        Admin,
        User
    }

    public record LoginPayload
    {
        public string? Username { get; set; }
        public string? Email { get; set; }
        public required string Password { get; set; }
    }
}
