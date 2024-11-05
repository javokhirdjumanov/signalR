using Core.Common.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chat.DB.Models
{
    public class Message : AuditableBase<int>
    {
        [Column("sender_id")]
        [ForeignKey(nameof(Sender))]
        public int SenderId { get; set; }

        [Column("chat_id")]
        [ForeignKey(nameof(Chat))]
        public int ChatId { get; set; }

        [Column("content")]
        public required string Content { get; set; }

        [Column("sent_at")]
        public DateTime SentAt { get; set; }

        [Column("is_read")]
        public bool IsRead { get; set; } = false;

        public User Sender { get; set; } = default!;
        public Chat Chat { get; set; } = default!;
    }
}
