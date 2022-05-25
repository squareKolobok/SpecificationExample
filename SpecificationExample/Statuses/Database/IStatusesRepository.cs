using System.Collections.Generic;
using SpecificationExample.Statuses.Models;

namespace SpecificationExample.Statuses.Database
{
    public interface IStatusesRepository
    {
        IEnumerable<Status> GetStatuses();

        void AddStatus(Status status);
    }
}