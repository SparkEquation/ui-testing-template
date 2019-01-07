using System.Linq;
using System.Threading;
using SparkEquation.Tests.AutomationTemplate;
using SparkEquation.Tests.AutomationTemplate.Infrastructure.TestRail;

namespace Objectivity.Test.Automation.Tests.Features
{
    using System;
    using Common;
    using Common.Logger;
    using System.Collections.Generic;
    using TechTalk.SpecFlow;

    /// <inheritdoc />
    /// <summary>
    /// The base class for all tests <see href="https://github.com/ObjectivityLtd/Test.Automation/wiki/ProjectTestBase-class">More details on wiki</see>
    /// </summary>
    [Binding]
    public class ProjectTestBase : TestBase
    {
        private readonly ScenarioContext scenarioContext;

        //private DriverContext driverContext = new DriverContext();
        public static Dictionary<string, DriverContext> Drivers = new Dictionary<string, DriverContext>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectTestBase"/> class.
        /// </summary>
        /// <param name="scenarioContext"> Scenario Context </param>
        public ProjectTestBase(ScenarioContext scenarioContext)
        {
            if (scenarioContext == null)
            {
                throw new ArgumentNullException("scenarioContext");
            }

            this.scenarioContext = scenarioContext;
        }

        /// <summary>
        /// Gets or sets logger instance for driver
        /// </summary>
        public TestLogger LogTest
        {
            get { return DriverContext.LogTest; }

            set { DriverContext.LogTest = value; }
        }

        /// <summary>
        /// Gets the browser manager
        /// </summary>
        protected DriverContext DriverContext => Drivers[Thread.CurrentThread.ManagedThreadId.ToString()];

        /// <summary>
        /// Before the class.
        /// </summary>
        [BeforeFeature]
        public static void BeforeClass()
        {
            var id = Thread.CurrentThread.ManagedThreadId.ToString() ?? "";
            if (!Drivers.ContainsKey(id))
            {
                try
                {
                    var baseDir = AppDomain.CurrentDomain.BaseDirectory;
                    var driver = new DriverContext
                    {
                        CurrentDirectory = baseDir
                    };
                    Drivers[id] = driver;
                    driver.Start();
                }
                catch
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// After the class.
        /// </summary>
        [AfterFeature]
        public static void AfterClass()
        {
            var id = Thread.CurrentThread.ManagedThreadId.ToString();
            if (Drivers.ContainsKey(id))
            {
                Drivers[id].Stop();
                Drivers.Remove(id);
            }
        }

        /// <summary>
        /// Before the test.
        /// </summary>
        [BeforeScenario]
        public void BeforeScenario()
        {
            var id = Thread.CurrentThread.ManagedThreadId.ToString();
            scenarioContext["DriverContext"] = Drivers[id];
        }

        [AfterScenario]
        public void AfterScenario()
        {
            var id = scenarioContext.ScenarioInfo.GetTRIds().FirstOrDefault();
            if (id == 0)
            {
                return;
            }

            foreach (var suiteRunPair in TestTearDown.SuitRuns)
            {
                TestTearDown.TestRailsUpdater.UpdateSuiteExecutionResult(suiteRunPair.Key, suiteRunPair.Value, id, scenarioContext.ScenarioExecutionStatus);
            }
        }
    }
}
