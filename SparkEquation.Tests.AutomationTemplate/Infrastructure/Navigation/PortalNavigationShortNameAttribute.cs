using System;

namespace SparkEquation.Tests.AutomationTemplate.Infrastructure.Navigation
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true, Inherited = false)]
    public class PortalNavigationShortNameAttribute : Attribute
    {
        public static readonly PortalNavigationLinkAttribute Default = new PortalNavigationLinkAttribute();
        public string ShortName { get; protected set; }

        public PortalNavigationShortNameAttribute()
            : this(string.Empty)
        {

        }

        public PortalNavigationShortNameAttribute(string description)
        {
            ShortName = description;
        }

        public bool CompareShortName(string shortName)
        {
            return ShortName.ToLowerInvariant().Trim() == shortName.ToLowerInvariant().Trim();
        }
    }
}
