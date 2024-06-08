using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApi.Models
{
    [Table("TodoItems", Schema = "todo")]
    public class TodoItem: BaseEntity
    {
        public string name { get; set; }
        public bool iscomplete { get; set; }

        public long memberinfoid { get; set; }
        public MemberInfo memberinfo { get; set; }
    }
}
