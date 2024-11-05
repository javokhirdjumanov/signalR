using Core.Common.Models;

namespace Chat.DB.Models
{
    public class User : AuditableBase<int>
    {
        public required string Username { get; set; }
        public required string PasswordHash { get; set; }
    }
}
