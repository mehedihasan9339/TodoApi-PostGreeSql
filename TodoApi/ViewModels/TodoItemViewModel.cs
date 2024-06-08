namespace TodoApi.ViewModels
{
    public class TodoItemViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }

        public long MemberInfoId { get; set; }
    }
}
