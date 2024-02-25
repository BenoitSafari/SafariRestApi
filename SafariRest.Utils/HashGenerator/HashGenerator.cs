namespace SafariRest.Utils;

public static class HashGenerator
{
    private static readonly int DefaultSalt = 10;

    public static string HashString(string str, int? salt) =>
        BCrypt.Net.BCrypt.HashPassword(str, salt ?? DefaultSalt);

    public static bool CompareString(string str, string hash) =>
        BCrypt.Net.BCrypt.Verify(str, hash);
}
