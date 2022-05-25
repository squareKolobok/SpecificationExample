using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SpecificationExample.Database;
using SpecificationExample.Statuses.Models;

namespace SpecificationExample.Statuses.Database
{
    public class StatusesRepository : IStatusesRepository
    {
        private readonly ApplicationContext context;

        private static Expression<Func<TaskStatus, Status>> toBl = status => new Status()
        {
            Id = status.Id,
            Name = status.Name
        };

        public StatusesRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public void AddStatus(Status status)
        {
            var taskStatus = new TaskStatus()
            {
                Id = status.Id,
                Name = status.Name
            };

            context.Add(taskStatus);
            context.SaveChanges();
        }

        public IEnumerable<Status> GetStatuses()
        {
            return context.Statuses.Select(toBl);
        }
    }
}