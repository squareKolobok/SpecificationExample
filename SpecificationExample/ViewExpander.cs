using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Razor;

namespace SpecificationExample
{
    public class ViewExpander : IViewLocationExpander 
    {

        public void PopulateValues(ViewLocationExpanderContext context)
        { }

        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            var location = viewLocations.ToList();
            location.AddRange(new []
            {
                "/{1}/Views/{0}.cshtml",
                "/Shared/Views/{0}.cshtml",
                "/Shared/Views/Layouts/{0}.cshtml",
            });

            return location;
        }
    }
}