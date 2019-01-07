using System;
using System.Linq;

namespace SparkEquation.Tests.AutomationTemplate.Infrastructure.Navigation
{
    public static class PageNavigationExtensions
    {
        public static PortalNavigationLinkAttribute GetPortalNavigationLinkAttribute(
            this PageShortname enumValue)
        {
            return GetAttribute<PortalNavigationLinkAttribute>(enumValue);
        }

        public static PortalNavigationShortNameAttribute GetPortalNavigationShortNameAttribute(
            this PageShortname enumValue)
        {
            return GetAttribute<PortalNavigationShortNameAttribute>(enumValue);
        }

        private static T GetAttribute<T>(PageShortname enumValue) where T : Attribute
        {
            var memberInfo = typeof(PageShortname).GetMember(enumValue.ToString())
                .FirstOrDefault();
            if (memberInfo != null)
            {
                var attribute = (T) 
                    memberInfo.GetCustomAttributes(typeof(T), false)
                        .FirstOrDefault();
                return attribute;
            }
            return null;
        }

        public static string GetSubUrl(this PageShortname enumValue)
        {
            return enumValue.GetPortalNavigationLinkAttribute()?.Description;
        }

        public static string GetUrl(this PageShortname enumValue, string baseUrl)
        {
            var suburl = enumValue.GetSubUrl();
            return baseUrl + suburl ?? "";
        }

        public static string GetSubUrlByShortName(this string shortName)
        {
            foreach (var item in Enum.GetValues(typeof(PageShortname)))
            {
                var attr = GetPortalNavigationShortNameAttribute((PageShortname)item);
                if (attr != null)
                {
                    if (attr.CompareShortName(shortName))
                    {
                        return GetSubUrl((PageShortname) item);
                    }
                }
            }

            return null;
        }
    }
}
