using Chat.Auth.Dtos;
using Chat.DB;
using Chat.DB.Models;
using Microsoft.EntityFrameworkCore;

namespace Chat.Auth
{
    public class AuthServiceAsync : IAuthServiceAsync
    {
        private readonly AppDbContext _context;
        public AuthServiceAsync(AppDbContext context)
        {
            _context = context;
        }

        public Task<object> GetMeAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<TokenResult> SignAsync(SignDto dto)
        {
            try
            {
                if (string.IsNullOrEmpty(dto.Username) || string.IsNullOrEmpty(dto.Password))
                    throw new BadRequestException("Username or password cannot be empty.");

                var userExisted = await this._context.Users
                     .AnyAsync(x => x.Username == dto.Username);

                // That registration
                if (!userExisted)
                {
                    User user = new()
                    {
                        PasswordHash = EnvironmentHelper.IsProduction
                              ? PasswordHelper.Encrypt(dto.Password)
                              : dto.Password,
                        Username = dto.Username,
                        RoleId = (int)EnumRoles.Client
                    };

                    this._context.Users.Add(user);
                    await this._context.SaveChangesAsync();

                    return await this.GenerateTokenAsync(user.Id);
                }

                var storageUser = await this._context.Users
                     .Include(x => x.Role)
                     .FirstOrDefaultAsync(x => x.Username == dto.Username);

                if (storageUser is null || !storageUser.IsValidPassword(dto.Password))
                    throw new BadRequestException("Password is incorrect !");

                return await this.GenerateTokenAsync(storageUser.Id);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                throw new ApplicationException($"{ex.Message}");
            }
        }
    }
}
