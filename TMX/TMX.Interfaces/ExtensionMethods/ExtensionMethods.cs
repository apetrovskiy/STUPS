namespace Tmx.Interfaces.ExtensionMethods
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TestStructure;

    public static class ExtensionMethods
    {
        public static string GetTimeTaken(this DateTime finishTime, DateTime startTime)
        {
            TimeSpan resultSpan;
            if (DateTime.MinValue == startTime)
                return string.Format("{0:00}:{1:00}:{2:00}", 0, 0, 0);
            if (DateTime.MinValue < finishTime)
                resultSpan = finishTime - startTime;
            else
                resultSpan = DateTime.Now - startTime;
            return string.Format("{0:00}:{1:00}:{2:00}", (int)resultSpan.TotalHours % 60, (int)resultSpan.TotalMinutes % 60, (int)resultSpan.TotalSeconds % 60);
        }

        public static TestStatuses GetOveralStatus(this IEnumerable<ITestSuite> suites)
        {
            var testSuites = suites as ITestSuite[] ?? suites.ToArray();
            return testSuites.Any(suite => TestStatuses.Failed == suite.enStatus)
                ? TestStatuses.Failed
                : testSuites.Any(suite => TestStatuses.KnownIssue == suite.enStatus)
                    ? TestStatuses.KnownIssue
                    : testSuites.Any(suite => TestStatuses.Passed == suite.enStatus)
                        ? TestStatuses.Passed
                        : TestStatuses.NotTested;
        }
    }
}