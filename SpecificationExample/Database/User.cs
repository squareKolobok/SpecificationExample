using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SpecificationExample.Database
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public DateTime DateCreate { get; set; } = DateTime.Now;
        public DateTime DateUpdate { get; set; } = DateTime.Now;
        public IEnumerable<UserTask> UserTasks = new List<UserTask>();
    }
}