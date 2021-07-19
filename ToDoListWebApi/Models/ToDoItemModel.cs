namespace ToDoListWebApi.Models
{
    public class ToDoItemModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
    }
}