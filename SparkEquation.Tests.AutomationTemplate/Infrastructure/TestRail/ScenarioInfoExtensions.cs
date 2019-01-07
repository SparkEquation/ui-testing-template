using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace SparkEquation.Tests.AutomationTemplate.Infrastructure.TestRail
{
    public static class ScenarioInfoExtensions
    {
        private const string TagStart = "TC_";

        public static List<int> GetTRIds(this ScenarioInfo scenarioInfo)
        {
            var tagMatch = scenarioInfo.Tags.Where(x => x.StartsWith(TagStart)).Select(x => x?.Replace(TagStart, ""))
                .Select(x => Convert.ToInt32(x)).ToList();
            return tagMatch;
        }
    }
}
