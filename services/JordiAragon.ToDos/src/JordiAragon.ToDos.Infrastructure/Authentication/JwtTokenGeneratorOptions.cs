namespace JordiAragon.ToDos.Infrastructure.Authentication
{
    public class JwtTokenGeneratorOptions
    {
        public const string Section = "JwtTokenGenerator";

        public string Secret { get; init; }

        public int ExpiryMinutes { get; init; }

        public string Issuer { get; init; }

        public string Audience { get; init; }
    }
}