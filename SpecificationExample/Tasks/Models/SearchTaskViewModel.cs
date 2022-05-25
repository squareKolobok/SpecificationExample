namespace SpecificationExample.Tasks.Models
{
    public class SearchTaskViewModel
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? AuthorId { get; set; }
        public int? StatusId { get; set; }
    }
}