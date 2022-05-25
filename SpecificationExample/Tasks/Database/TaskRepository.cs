using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoFilterSpecification;
using SpecificationExample.Database;
using SpecificationExample.Tasks.Models;

namespace SpecificationExample.Tasks.Database
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationContext context;

        private readonly Expression<Func<UserTask, UserTaskInfo>> toBl = 
            x => new UserTaskInfo()
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                AuthorId = x.AuthorId,
                Author = x.Author.Name,
                StatusId = x.StatusId,
                Status = x.Status.Name
            };

        public TaskRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public void AddTask(UserTaskModification task)
        {
            var taskDb = new UserTask()
            {
                Title = task.Title,
                Description = task.Description,
                AuthorId = task.AuthorId,
                StatusId = task.StatusId
            };

            context.Tasks.Add(taskDb);
            context.SaveChanges();
        }

        public UserTaskInfo GetTask(Specification<UserTaskInfo> where)
        {
            return context.Tasks.Select(toBl).Where(where).First();
        }

        public IEnumerable<UserTaskInfo> GetTasks()
        {
            return context.Tasks.Select(toBl);
        }

        public IEnumerable<UserTaskInfo> GetTasks(Specification<UserTaskInfo> where)
        {
            return context.Tasks.Select(toBl).Where(where);
        }

        public void UpdateTask(UserTaskModification task)
        {
            var taskDb = context.Tasks.First(x => x.Id == task.Id);

            taskDb.Title = task.Title;
            taskDb.Description = task.Description;
            taskDb.AuthorId = task.AuthorId;
            taskDb.StatusId = task.StatusId;

            context.SaveChanges();
        }
    }
}