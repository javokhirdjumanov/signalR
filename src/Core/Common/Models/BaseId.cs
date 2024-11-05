using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Common.Models
{
    public abstract class BaseId<TId> where TId : struct
    {
        [Column("id")] public TId Id { get; set; }
    }
}
