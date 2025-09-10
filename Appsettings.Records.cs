namespace TodoListBackend
{
    public partial record Appsettings
    {
        public record JwtSettings(string Key, string Issuer, string Audience);

        public record ConnectionStringsSettings(string DefaultConnection);
    }
}
