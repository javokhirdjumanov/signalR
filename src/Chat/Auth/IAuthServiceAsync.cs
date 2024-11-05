using Chat.Auth.Dtos;

namespace Chat.Auth
{
    public interface IAuthServiceAsync
    {
        Task<TokenResult> SignAsync(SignDto dto);
        Task<object> GetMeAsync(int userId);
    }
}
