using System;
using System.Linq.Expressions;
using AutoFilterSpecification;
using AutoFilterSpecification.Attributes;
using SpecificationExample.Users.Attributes;

namespace SpecificationExample.Users.Models
{
    public class SearchUsersViewModel
    {
        public int? Id { get; set; }
        [StringContains]
        public string Name { get; set; }
        [OnlyAdmin]
        public bool? IsOnlyAdmins { get; set; }
    }
}