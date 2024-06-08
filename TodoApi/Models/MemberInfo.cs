using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApi.Models
{
    [Table("MemberInfos", Schema = "todo")]
    public class MemberInfo:BaseEntity
    {
        public string name { get; set; }
        public string phone { get; set; }
        public DateTime? dateofbirth { get; set; }
    }
}
