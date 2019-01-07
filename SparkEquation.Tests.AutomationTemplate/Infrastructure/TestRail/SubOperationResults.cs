using System.Collections.Generic;
using System.Threading.Tasks;

namespace SparkEquation.Tests.AutomationTemplate.Infrastructure.TestRail
{
    public class SubOperationResults
    {
        public List<Task> Tasks => new List<Task>();
        public ulong RunId { get; set; }
    }
}
