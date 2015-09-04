namespace Tmx.Server.Web.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using Core;
    using Core.Types.Remoting;
    using DotLiquid.NamingConventions;
    using Interfaces.Remoting;
    using Interfaces.Remoting.Web;
    using Interfaces.TestStructure;
    using DotLiquid;
    using Nancy.ViewEngines.DotLiquid;
    using Interfaces;

    public class Initializer : IInitializer
    {
        public virtual void RegisterTypes()
        {
            // .NET types
            Template.RegisterSafeType(typeof(Guid), member => member.ToString());
            
            Template.RegisterSafeType(typeof(Dictionary<string, string>), member => member.ToString());
            Template.RegisterSafeType(typeof(Dictionary<string, object>), member => member.ToString());
            Template.RegisterSafeType(typeof(IDictionary<string, string>), member => member.ToString());
            Template.RegisterSafeType(typeof(IDictionary<string, object>), member => member.ToString());
            
            /*
            Template.RegisterSafeType(typeof(Dictionary<string, string>), new[] { "Keys", "Values", "Count" });
            Template.RegisterSafeType(typeof(Dictionary<string, object>), new[] { "Keys", "Values", "Count" });
            Template.RegisterSafeType(typeof(IDictionary<string, string>), new[] { "Keys", "Values", "Count" });
            Template.RegisterSafeType(typeof(IDictionary<string, object>), new[] { "Keys", "Values", "Count" });
            */
            // Template.RegisterSafeType(typeof(KeyValuePair<string, string>), new[] { "Key", "Value" });
            Template.RegisterSafeType(typeof(KeyValuePair<string, string>), member => member.ToString());
            // Template.RegisterSafeType(typeof(KeyValuePair<string, object>), new[] { "Key", "Value", "Get_Key", "Get_Value" });
            // Template.RegisterSafeType(typeof(KeyValuePair<string, object>), new[] { "Key", "Value" });
            Template.RegisterSafeType(typeof(KeyValuePair<string, object>), member => member.ToString());
            // enumerations
            Template.RegisterSafeType(typeof(TestResultOrigins), member => member.ToString());
            Template.RegisterSafeType(typeof(TestRunStatuses), member => member.ToString());
            Template.RegisterSafeType(typeof(TestRunStartTypes), member => member.ToString());
            Template.RegisterSafeType(typeof(TestTaskStatuses), member => member.ToString());
            Template.RegisterSafeType(typeof(TestTaskExecutionTypes), member => member.ToString());
            Template.RegisterSafeType(typeof(TestClientStatuses), member => member.ToString());
            Template.RegisterSafeType(typeof(ServerControlCommands), member => member.ToString());
            Template.RegisterSafeType(typeof(TestLabStatuses), member => member.ToString());
            Template.RegisterSafeType(typeof(TestStatuses), member => member.ToString());
            // specific types
            Template.RegisterSafeType(typeof(TestSuite), new[] { "Id", "Name", "Status", "Description", "TestScenarios", "PlatformId", "Statistics", "TimeSpent", "Timestamp", "Tags", "Statistics.All", "Statistics.Passed", "GetAll", "GetPassed", "GetFailed", "GetPassedButWithBadSmell", "GetNotTested" });
            Template.RegisterSafeType(typeof(TestScenario), new[] { "Id", "Name", "Status", "Description", "TestResults", "PlatformId", "Statistics", "TimeSpent", "Timestamp", "Tags", "TestCases", "Statistics.All", "Statistics.Passed", "GetAll", "GetPassed", "GetFailed", "GetPassedButWithBadSmell", "GetNotTested" });
            Template.RegisterSafeType(typeof(TestResult), new[] { "Id", "Name", "Status", "Description", "Origin", "PlatformId", "Timestamp", "Details", "ScriptName", "LineNumber", "Position", "Error", "Code", "Parameters", "TimeSpent", "Generated", "Screenshot", "ListDetailNames" });
            Template.RegisterSafeType(typeof(TestResultDetail), new[] { "Name", "Timestamp", "GetDetail", "DetailStatus", "DetailType", "TextDetail", "ErrorDetail", "ScreenshotDetail", "LogDetail", "ExternalData" });
            Template.RegisterSafeType(typeof(ITestSuite), new[] { "Id", "Name", "Status", "Description", "TestScenarios", "PlatformId", "Statistics", "TimeSpent", "Timestamp", "Tags", "Statistics.All", "Statistics.Passed", "GetAll", "GetPassed", "GetFailed", "GetPassedButWithBadSmell", "GetNotTested" });
            Template.RegisterSafeType(typeof(ITestScenario), new[] { "Id", "Name", "Status", "Description", "TestResults", "PlatformId", "Statistics", "TimeSpent", "Timestamp", "Tags", "TestCases", "Statistics.All", "Statistics.Passed", "GetAll", "GetPassed", "GetFailed", "GetPassedButWithBadSmell", "GetNotTested" });
            Template.RegisterSafeType(typeof(ITestResult), new[] { "Id", "Name", "Status", "Description", "Origin", "PlatformId", "Timestamp", "Details", "ScriptName", "LineNumber", "Position", "Error", "Code", "Parameters", "TimeSpent", "Generated", "Screenshot", "ListDetailNames" });
            Template.RegisterSafeType(typeof(ITestResultDetail), new[] { "Name", "Timestamp", "GetDetail", "DetailStatus", "DetailType", "TextDetail", "ErrorDetail", "ScreenshotDetail", "LogDetail", "ExternalData" });
            // Template.RegisterSafeType(typeof(TestWorkflow), new[] { "Id", "Name", "TestLabId", "Description", "ParametersPageName" });
            Template.RegisterSafeType(typeof(ITestWorkflow), new[] { "Id", "Name", "TestLabId", "Description", "ParametersPageName", "DefaultData", "IsDefault" }); // ??
            Template.RegisterSafeType(typeof(TestWorkflow), new[] { "Id", "Name", "TestLabId", "Description", "ParametersPageName", "DefaultData", "IsDefault" });
            // Template.RegisterSafeType(typeof(ITestRun), new[] { "Id", "Name", "WorkflowId", "TestLabId", "Description", "Status", "StartType", "Data", "TestSuites", "StartTime", "TimeTaken", "GetTestLabName" });
            // Template.RegisterSafeType(typeof(TestRun), new[] { "Id", "Name", "WorkflowId", "TestLabId", "Description", "Status", "StartType", "Data", "TestSuites", "StartTime", "TimeTaken", "GetTestLabName" });
            // Template.RegisterSafeType(typeof(ITestRun), new[] { "Id", "Name", "WorkflowId", "TestLabId", "Description", "Status", "StartType", "Data", "TestSuites", "StartTime", "GetTimeTaken", "GetTestLabName" });
            // Template.RegisterSafeType(typeof(TestRun), new[] { "Id", "Name", "WorkflowId", "TestLabId", "Description", "Status", "StartType", "Data", "TestSuites", "StartTime", "GetTimeTaken", "GetTestLabName" });
            // Template.RegisterSafeType(typeof(ITestRun), new[] { "Id", "Name", "WorkflowId", "TestLabId", "Description", "Status", "StartType", "Data", "TestSuites", "StartTime", "GetTimeTaken", "GetTestLabName", "TestPlatforms", "CreatedTime", "BeforeActions", "AfterActions", "CancelActions", "FailureActions" });
            Template.RegisterSafeType(typeof(ITestRun), new[] { "Id", "Name", "WorkflowId", "TestLabId", "Description", "Status", "TestStatus", "StartType", "Data", "TestSuites", "StartTime", "GetTimeTaken", "GetTestLabName", "TestPlatforms", "CreatedTime", "BeforeActions", "AfterActions", "CancelActions", "FailureActions" });
            // Template.RegisterSafeType(typeof(TestRun), new[] { "Id", "Name", "WorkflowId", "TestLabId", "Description", "Status", "StartType", "Data", "TestSuites", "StartTime", "GetTimeTaken", "GetTestLabName", "TestPlatforms", "CreatedTime", "BeforeActions", "AfterActions", "CancelActions", "FailureActions" });
            Template.RegisterSafeType(typeof(TestRun), new[] { "Id", "Name", "WorkflowId", "TestLabId", "Description", "Status", "TestStatus", "StartType", "Data", "TestSuites", "StartTime", "GetTimeTaken", "GetTestLabName", "TestPlatforms", "CreatedTime", "BeforeActions", "AfterActions", "CancelActions", "FailureActions" });
            // Template.RegisterSafeType(typeof(CommonData), new[] { "Data" });
            Template.RegisterSafeType(typeof(CommonData), new[] { "Data" });
            Template.RegisterSafeType(typeof(ICommonData), new[] { "Data" });
            Template.RegisterSafeType(typeof(ICodeBlock), new[] { "Code" });
            Template.RegisterSafeType(typeof(CodeBlock), new[] { "Code" });
            Template.RegisterSafeType(typeof(TestLab), new[] { "Id", "Name", "Description", "Status" });
            Template.RegisterSafeType(typeof(TestTask), new[] { "Id", "Name", "StartTime", "TaskStatus", "TaskFinished", "TaskResult", "TimeTaken", "ClientId", "GetTimeTaken" });
            Template.RegisterSafeType(typeof(TestClient), new[] { "Id", "Hostname", "Fqdn", "Username", "CustomString", "Status", "TaskId", "TaskName", "DetailedStatus" });
            // Template.RegisterSafeType(typeof(CommonDataItem), new[] { "Key", "Value" });
            Template.RegisterSafeType(typeof(ICommonDataItem), new[] { "Key", "Value" });
            Template.RegisterSafeType(typeof(CommonDataItem), new[] { "Key", "Value" });
            Template.RegisterSafeType(typeof(TestStat), new[] { "All", "Passed", "Failed", "PassedButWithBadSmell", "NotTested", "TimeSpent" });
            Template.RegisterSafeType(typeof(TestStat), member => member.ToString());

            // just for copying the Nancy.ViewEngines.DotLiquid assembly to dependant projects
            var drop = new DynamicDrop(new ExpandoObject());
        }

        public void SetDotLiquidNamingConventions()
        {
            // Template.NamingConvention = new CSharpNamingConvention();
            Template.NamingConvention = new RubyNamingConvention();
        }
    }
}