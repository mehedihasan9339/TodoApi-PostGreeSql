namespace TodoApi.ViewModels
{
    public class MemberTodoItemDTO
    {
        public long todoitemid { get; set; }
        public string todoitemname { get; set; }
        public bool iscomplete { get; set; }
        public long memberinfoid { get; set; }
        public string membername { get; set; }
        public string memberphone { get; set; }
        public DateTime? memberdateofbirth { get; set; }
    }

}
