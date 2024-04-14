using System.ComponentModel.DataAnnotations;

namespace FilesSafeReserve.Data.Models;

public class ModelBase<IdType>
{
    [Key]
    public IdType? Id { get; set; }
}
