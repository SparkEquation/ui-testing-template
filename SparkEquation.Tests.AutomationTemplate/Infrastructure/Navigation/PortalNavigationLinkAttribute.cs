using System;

namespace SparkEquation.Tests.AutomationTemplate.Infrastructure.Navigation
{
    [AttributeUsage(AttributeTargets.Field)]
    public class PortalNavigationLinkAttribute : Attribute
    {
        public static readonly PortalNavigationLinkAttribute Default = new PortalNavigationLinkAttribute();
        private string _description;

        public PortalNavigationLinkAttribute()
            : this(string.Empty)
        {
        }

        public PortalNavigationLinkAttribute(string description)
        {
            _description = description;
        }

        public virtual string Description => GetDescriptionValue();

        protected string GetDescriptionValue()
        {
            return _description;
        }

        protected void SetDescriptionValue(string value)
        {
            _description = value;
        }

        public override bool Equals(object obj)
        {
            if (obj == this)
                return true;
            if (obj is PortalNavigationLinkAttribute)
            {
                var descriptionAttribute = obj as PortalNavigationLinkAttribute;
                return descriptionAttribute.Description == this.Description;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return Description.GetHashCode();
        }

        public override bool IsDefaultAttribute()
        {
            return Equals(Default);
        }
    }
}
