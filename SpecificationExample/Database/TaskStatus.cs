using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SpecificationExample.Database
{
    public class TaskStatus
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(200)]
        public string Name { get; set; }
        public IEnumerable<UserTask> UserTasks { get; set; } = new List<UserTask>();
    }
}