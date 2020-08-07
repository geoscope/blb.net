namespace BLB.Shared.Net.Models
{
    public class AppSettings
    {
        public string JwtSharedSecret { get; set; }
        public string SystemSalt { get; set; }
        public bool JwtValidateAudience { get; set; }
        public bool JwtValidateIssuer { get; set; }
        public bool JwtValidateLifetime { get; set; }
    }
}
