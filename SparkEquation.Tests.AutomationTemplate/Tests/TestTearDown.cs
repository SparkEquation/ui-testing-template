using System;
using System.Collections.Generic;
using SparkEquation.Tests.AutomationTemplate.Infrastructure.TestRail;
using NUnit.Framework;
using Objectivity.Test.Automation.Tests.Features;
using TestRail;
using TestRail.Types;

namespace SparkEquation.Tests.AutomationTemplate
{
    /// <summary>
    /// A class to make sure ll drivers are killed as expected
    /// </summary>
    [SetUpFixture]
    public class TestTearDown
    {
        // Tightly coupled as there is no abstrction over updaters. May be a subject to change in future.
        public static TestRailStatusUpdater TestRailsUpdater = new TestRailStatusUpdater();
        
        public static ulong MilestoneId;
        public static Dictionary<ulong, ulong> SuitRuns;

        // Flag to avoid doublicate milestone creation
        private static bool CreatedMilestone = false;

        private static object _locker = new Object();

        [OneTimeSetUp]
        public void OpenConns()
        {
            if (CreatedMilestone)
            {
                return;
            }

            lock (_locker)
            {
                if (CreatedMilestone)
                {
                    return;
                }

                MilestoneId = TestRailsUpdater.CreateOrGetMilestone();
                var suits = TestRailsUpdater.GetSuites();
                SuitRuns = TestRailsUpdater.CreateRuns(suits, MilestoneId);
                CreatedMilestone = true;
            }
        }

        [OneTimeTearDown]
        public void CloseConnections()
        {
            foreach (var pair in SuitRuns)
            {
                TestRailsUpdater.CloseRun(pair.Value);
            }

            foreach (var item in ProjectTestBase.Drivers)
            {
                try
                {
                    item.Value.Stop();
                }
                catch (Exception e)
                {
                    // Do nothing, we are exiting here after all
                }
            }
        }
    }
}
