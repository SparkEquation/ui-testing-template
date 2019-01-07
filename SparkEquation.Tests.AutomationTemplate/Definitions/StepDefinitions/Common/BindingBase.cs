using System;
using SparkEquation.Tests.AutomationTemplate.Infrastructure;
using Objectivity.Test.Automation.Common;
using Objectivity.Test.Automation.Tests.PageObjects;
using TechTalk.SpecFlow;

namespace SparkEquation.Tests.AutomationTemplate.Definitions.StepDefinitions.Common
{
    public abstract class BindingBase<T> where T : ProjectPageBase
    {
        protected DriverContext _driverContext;
        protected ScenarioContext _scenarioContext;

        public SessionConfiguration Configuration => _scenarioContext["SessionConfig"] as SessionConfiguration;
        internal LoginData TalentAuthData => (_scenarioContext["Login.Talent"] as LoginData);
        internal LoginData OpsAuthData => (_scenarioContext["Login.Ops"] as LoginData);

        public BindingBase(ScenarioContext scenarioContext, SessionConfiguration config)
        {
            if (scenarioContext == null) throw new ArgumentNullException("scenarioContext");
            _scenarioContext = scenarioContext;
            _driverContext = _scenarioContext["DriverContext"] as DriverContext;
            _scenarioContext["SessionConfig"] = config;

            _scenarioContext["Login.Talent"] = config.TalentLoginData;
            _scenarioContext["Login.Ops"] = config.AdminLoginData;
        }

        protected virtual string PageKey => Page.ShortName.ToString();

        private T _page;

        protected T Page
        {
            get
            {
                if (_page == null)
                {
                    var config = (SessionConfiguration)_scenarioContext["SessionConfig"];
                    var type = typeof(T);
                    var firstConstructor = type.GetConstructors()[0];
                    var item = (T)firstConstructor.Invoke(new object[] {_driverContext, config});
                    _scenarioContext.Set(item, item.ShortName.ToString());
                    _page = item;
                }

                return _page;
            }
        }
    }
}
