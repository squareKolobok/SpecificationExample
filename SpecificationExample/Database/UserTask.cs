using System.ComponentModel.DataAnnotations;

namespace SpecificationExample.Database
{
    public class UserTask
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(200)]
        public string Title { get; set; }
        [MaxLength(1000)]
        public string Description { get; set; }
        public int AuthorId { get; set; }
        public int StatusId { get; set; }
        public User Author { get; set; }
        public TaskStatus Status { get; set; }
    }
}