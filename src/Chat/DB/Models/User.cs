using Core.Common.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chat.DB.Models
{
    public class User : AuditableBase<int>
    {
        [Column("username")]
        public required string Username { get; set; }

        [Column("password_hash")]
        public required string PasswordHash { get; set; }

        [Column("phone_number")]
        public string? PhoneNumber { get; set; }

        [Column("profile_picture_url")]
        public string? ProfilePictureUrl { get; set; }

        [Column("status")]
        public int Status { get; set; }
    }
}
