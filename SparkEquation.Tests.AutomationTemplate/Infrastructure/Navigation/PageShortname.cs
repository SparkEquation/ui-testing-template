
namespace SparkEquation.Tests.AutomationTemplate.Infrastructure.Navigation
{
    public enum PageShortname
    {
        OpsNavigationableAbstractPage,
        [PortalNavigationLink("/")]
        RootPage,
        [PortalNavigationLink("/")]
        LoginPage
    }
}
