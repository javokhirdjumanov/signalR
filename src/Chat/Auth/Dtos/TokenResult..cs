namespace Chat.Auth.Dtos
{
    public class TokenResult
    {
        public string AccessToken { get; set; } = default!;
        public string RefreshToken { get; set; } = default!;
        public DateTime ExpireDate { get; set; }
    }
}
