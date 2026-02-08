namespace IncuSmart.Core.Utils
{
    public static class JwtOptions
    {
        public static string Key { get; set; } = string.Empty;
        public static string Issuer { get; set; } = string.Empty;
        public static string Audience { get; set; } = string.Empty;
        public static int ExpireMinutes { get; set; }

        public static void Init(JwtOptionsDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            Key = dto.Key;
            Issuer = dto.Issuer;
            Audience = dto.Audience;
            ExpireMinutes = dto.ExpireMinutes;
        }
    }

    public class JwtOptionsDto
    {
        public string Key { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
        public int ExpireMinutes { get; set; }
    }
}
