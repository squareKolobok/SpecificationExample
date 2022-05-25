using System;

namespace AutoFilterSpecification.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class BindingByAttribute : Attribute
    {
        public BindingByAttribute (string propertyName)
        {
            PropertyName = propertyName;
        }

        public string PropertyName { get; private set; }
    }
}
