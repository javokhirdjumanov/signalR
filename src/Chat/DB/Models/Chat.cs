using Core.Common.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chat.DB.Models
{
    public class Chat : AuditableBase<int>
    {
        [Column("name")]
        public required string Name { get; set; }

        [Column("is_group_chat")]
        public bool IsGroupChat { get; set; }
    }
}
