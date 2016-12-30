/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/12/2014
 * Time: 5:44 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Server.Tests.Modules
{
    using System.Linq;
    using Nancy;
    using Nancy.Testing;
    using Interfaces.Remoting;
    using Interfaces.Server;
    using Core;
    using Logic.ObjectModel.Objects;
    using UnitTestingHelpers;
    using Xunit;
    
    /// <summary>
    /// Description of TestDataModuleTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture]
    public class TestDataModuleTestFixture
    {
        ITestWorkflow _workflow;
        ITestRun _testRun;
        const string ExpectedKey = "a1";
        const string ExpectedValue = "b1";
        
        public TestDataModuleTestFixture()
        {
            TestSettings.PrepareModuleTests();
            TestFactory.GetTestRunWithStatus(TestRunStatuses.Running);
            _workflow = WorkflowCollection.Workflows.First();
            _testRun = TestRunQueue.TestRuns.First();
        }
        
        [MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
        public void SetUp()
        {
            TestSettings.PrepareModuleTests();
            TestFactory.GetTestRunWithStatus(TestRunStatuses.Running);
            _workflow = WorkflowCollection.Workflows.First();
            _testRun = TestRunQueue.TestRuns.First();
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ShouldAcceptCommonDataItemSentToEmptyCommonDataAsJson()
        {
            var commonDataItem = GivenCommonDataItem(ExpectedKey, ExpectedValue);
            
            var response = WhenSendingCommonDataItemAsJson(commonDataItem);
            
            ThenHttpResponseIsCreated(response);
            ThenCommonDataItemMatches(commonDataItem);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ShouldAcceptCommonDataItemSentToEmptyCommonDataAsXml()
        {
            var commonDataItem = GivenCommonDataItem(ExpectedKey, ExpectedValue) as CommonDataItem;
            
            var response = WhenSendingCommonDataItemAsXml(commonDataItem);
            
            ThenHttpResponseIsCreated(response);
            ThenCommonDataItemMatches(commonDataItem);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ShouldAcceptCommonDataItemSentToNonEmptyCommonDataAsJson()
        {
            GivenNonEmptyCommonData();
            var commonDataItem = GivenCommonDataItem(ExpectedKey, ExpectedValue);
            
            var response = WhenSendingCommonDataItemAsJson(commonDataItem);
            
            ThenHttpResponseIsCreated(response);
            ThenCommonDataItemMatches(commonDataItem);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ShouldAcceptCommonDataItemSentToNonEmptyCommonDataAsXml()
        {
            GivenNonEmptyCommonData();
            var commonDataItem = GivenCommonDataItem(ExpectedKey, ExpectedValue) as CommonDataItem;
            
            var response = WhenSendingCommonDataItemAsXml(commonDataItem);
            
            ThenHttpResponseIsCreated(response);
            ThenCommonDataItemMatches(commonDataItem);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ShouldAcceptCommonDataItemSentForReplacementAsJson()
        {
            GivenNonEmptyCommonData();
            GivenDataItemWithKey(ExpectedKey, ExpectedValue);
            var commonDataItem = GivenCommonDataItem(ExpectedKey, ExpectedValue);
            
            var response = WhenSendingCommonDataItemAsJson(commonDataItem);
            
            ThenHttpResponseIsCreated(response);
            ThenCommonDataItemMatches(commonDataItem);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ShouldAcceptCommonDataItemSentForReplacementAsXml()
        {
            GivenNonEmptyCommonData();
            GivenDataItemWithKey(ExpectedKey, ExpectedValue);
            var commonDataItem = GivenCommonDataItem(ExpectedKey, ExpectedValue) as CommonDataItem;
            
            var response = WhenSendingCommonDataItemAsXml(commonDataItem);
            
            ThenHttpResponseIsCreated(response);
            ThenCommonDataItemMatches(commonDataItem);
        }
        // ============================================================================================================================
        
        void GivenNonEmptyCommonData()
        {
            TestRunQueue.TestRuns.First().Data.Data.Add("aaa", "bbb");
        }
        
        void GivenDataItemWithKey(string key, string value)
        {
            TestRunQueue.TestRuns.First().Data.Data.Add(key, value);
        }
        
        ICommonDataItem GivenCommonDataItem(string key, string value)
        {
            return new CommonDataItem { Key = key, Value = value };
        }
        
        BrowserResponse WhenSendingCommonDataItemAsJson(ICommonDataItem dataItem)
        {
            var browser = TestFactory.GetBrowserForTestDataModule();
            var urn = UrlList.TestData_Root + "/" + _testRun.Id + UrlList.TestData_CommonData_forClient_relPath;
            return browser.Post(urn, with => {
                with.JsonBody(dataItem);
                with.Accept("application/json");
            });
        }
        
        BrowserResponse WhenSendingCommonDataItemAsXml(CommonDataItem dataItem)
        {
            var browser = TestFactory.GetBrowserForTestDataModule();
            var urn = UrlList.TestData_Root + "/" + _testRun.Id + UrlList.TestData_CommonData_forClient_relPath;
            return browser.Post(urn, with => {
                with.XMLBody(dataItem);
                with.Accept("application/xml");
            });
        }
        
        void ThenHttpResponseIsCreated(BrowserResponse response)
        {
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }
        
        void ThenCommonDataItemMatches(ICommonDataItem dataItem)
        {
            Assert.Equal(_testRun.Data.Data[dataItem.Key], dataItem.Value);
        }
    }
}
