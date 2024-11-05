using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Common.Models
{
    public abstract class SoftDeletableBase<TId> : BaseId<TId>
        where TId : struct
    {
        [Column("is_deleted")]
        public bool IsDeleted { get; set; } = false;
    }
}
