namespace SpecificationExample.Tasks.Models
{
    public class UserTaskInfo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int AuthorId { get; set; }
        public string Author { get; set; }
        public int StatusId { get; set; }
        public string Status { get; set; }
    }
}