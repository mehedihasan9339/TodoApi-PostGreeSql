using System.ComponentModel.DataAnnotations;

namespace TodoApi.Models
{
    public class BaseEntity
    {
        [Key]
        public long id { get; set; }
    }
}
