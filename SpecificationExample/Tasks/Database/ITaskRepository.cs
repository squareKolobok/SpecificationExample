using System.Collections.Generic;
using AutoFilterSpecification;
using SpecificationExample.Tasks.Models;

namespace SpecificationExample.Tasks.Database
{
    public interface ITaskRepository
    {
        IEnumerable<UserTaskInfo> GetTasks();

        IEnumerable<UserTaskInfo> GetTasks(Specification<UserTaskInfo> where);

        UserTaskInfo GetTask(Specification<UserTaskInfo> where);

        void AddTask(UserTaskModification task);

        void UpdateTask(UserTaskModification task);
    }
}