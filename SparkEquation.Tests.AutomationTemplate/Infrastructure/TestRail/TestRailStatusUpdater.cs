using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TestRail;
using TestRail.Types;

namespace SparkEquation.Tests.AutomationTemplate.Infrastructure.TestRail
{
    public class TestRailStatusUpdater
    {
        #region Fields

        private ulong _testRailProjectId;

        private string _suffix { get; set; }
        private string _milestoneName { get; set; }

        private TestRailClient _client;

        #endregion

        public TestRailStatusUpdater()
        {
            var configurationCurrent = new ConfigurationProvider();
            var version = configurationCurrent.GetVersionMajor();

            _testRailProjectId = configurationCurrent.GetTestRailProjectId();
            _client = CreateTestRailClient();
            _suffix = CreateCurrentRunSuffix();
            _milestoneName = CreateMilestoneName(version);
        }

        public List<Suite> GetSuites()
        {
            if (_client == null)
            {
                return new List<Suite>();
            }

            return _client.GetSuites(_testRailProjectId);
        }

        public Dictionary<ulong, ulong> CreateRuns(List<Suite> suits, ulong milestoneId)
        {
            var results = new Dictionary<ulong, ulong>();
            foreach (var suite in suits)
            {
                var current = CreateRun(suite, milestoneId);
                if (current == null)
                {
                    continue;
                }

                results.Add(current.Value.Key, current.Value.Value);
            }

            return results;
        }

        public void CloseRun(ulong runId)
        {
            if (runId > 0 || _client != null)
            {
                _client.CloseRun(runId);
            }
        }

        public void UpdateSuiteExecutionResult(ulong suiteId, ulong runId, int id, ScenarioExecutionStatus status)
        {
            _client?.AddResultForCase(runId, (ulong)id, MapToReultStatus(status));
        }

        public ulong CreateOrGetMilestone()
        {
            if (_client == null)
            {
                return 0;
            }

            var milestones = _client.GetMilestones(_testRailProjectId);

            if (milestones.Any(x => x.Name == _milestoneName))
            {
                return milestones.First(x => x.Name == _milestoneName).ID;
            }

            // Auto due +1 hour to make sure it wont stay actual forever
            var milestoneResult = _client.AddMilestone(1, _milestoneName);
            return milestoneResult.Value;
        }

        #region Private methods

        private static ResultStatus MapToReultStatus(ScenarioExecutionStatus statusSrc)
        {
            switch (statusSrc)
            {
                case ScenarioExecutionStatus.OK:
                    return ResultStatus.Passed;
                case ScenarioExecutionStatus.UndefinedStep:
                case ScenarioExecutionStatus.StepDefinitionPending:
                case ScenarioExecutionStatus.BindingError:
                    return ResultStatus.Untested;
                case ScenarioExecutionStatus.TestError:
                    return ResultStatus.Failed;
                default:
                    return ResultStatus.Failed;
            }
        }

        private string CreateMilestoneName(string version)
        {
            return $"v{version.Trim()}";
        }

        private TestRailClient CreateTestRailClient()
        {
            var configurationCurrent = new ConfigurationProvider();
            var userName = configurationCurrent.GetTestRailUserName();
            var userPassword = configurationCurrent.GetTestRailPassword();
            var testRailUrl = configurationCurrent.GetTestRailUrl();
            if (userName == "" || userPassword == "" || testRailUrl == "")
            {
                return null;
            }

            return new global::TestRail.TestRailClient(testRailUrl, userName, userPassword);
        }

        private string CreateCurrentRunSuffix()
        {
            return DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
        }

        
        private KeyValuePair<ulong, ulong>? CreateRun(Suite suite, ulong milestoneId)
        {
            if (_client == null)
            {
                return null;
            }

            var runName = $"Automated Run {_suffix} :: {suite.Name}";
            var runCreationResult = _client.AddRun(1, suite.ID.Value, runName, runName, milestoneId);
            var runId = runCreationResult.Value;
            return new KeyValuePair<ulong, ulong>(suite.ID.Value, runId);
        }

        #endregion
    }
}
