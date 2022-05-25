using SpecificationExample.Tasks.Models;
using AutoFilterSpecification;

namespace SpecificationExample.Tasks
{
    public static class Specifications
    {
        public static Specification<UserTaskInfo> ById(int id)
            => new Specification<UserTaskInfo>(x => x.Id == id);
    }
}