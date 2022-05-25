using AutoFilterSpecification;
using SpecificationExample.Users.Models;

namespace SpecificationExample.Users
{
    public static class Specifications
    {
        public static Specification<User> ById(int id) 
            => new Specification<User>(x => x.Id == id);
        
        public static Specification<User> Admins { get; set; } = 
            new Specification<User>(x => x.Id <= 20);
    }
}