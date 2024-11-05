using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Common.Models
{
    public abstract class AuditableBase<T> : SoftDeletableBase<T>
        where T : struct
    {
        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
