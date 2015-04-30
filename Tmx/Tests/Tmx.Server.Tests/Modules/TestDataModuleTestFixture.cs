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
    using Library.ObjectModel.Objects;
    using Nancy;
    using Nancy.Testing;
    using MbUnit.Framework;
    using NUnit.Framework;
    using Interfaces.Remoting;
    using Interfaces.Server;
    using Core;
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
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Should_accept_common_data_item_sent_to_empty_CommonData_as_json()
        {
            var commonDataItem = GIVEN_CommonDataItem(ExpectedKey, ExpectedValue);
            
            var response = WHEN_SendingCommonDataItem_as_Json(commonDataItem);
            
            THEN_Http_Response_Is_Created(response);
            THEN_CommonDataItem_Matches(commonDataItem);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Should_accept_common_data_item_sent_to_empty_CommonData_as_xml()
        {
            var commonDataItem = GIVEN_CommonDataItem(ExpectedKey, ExpectedValue) as CommonDataItem;
            
            var response = WHEN_SendingCommonDataItem_as_Xml(commonDataItem);
            
            THEN_Http_Response_Is_Created(response);
            THEN_CommonDataItem_Matches(commonDataItem);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Should_accept_common_data_item_sent_to_non_empty_CommonData_as_json()
        {
            GIVEN_non_empty_CommonData();
            var commonDataItem = GIVEN_CommonDataItem(ExpectedKey, ExpectedValue);
            
            var response = WHEN_SendingCommonDataItem_as_Json(commonDataItem);
            
            THEN_Http_Response_Is_Created(response);
            THEN_CommonDataItem_Matches(commonDataItem);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Should_accept_common_data_item_sent_to_non_empty_CommonData_as_xml()
        {
            GIVEN_non_empty_CommonData();
            var commonDataItem = GIVEN_CommonDataItem(ExpectedKey, ExpectedValue) as CommonDataItem;
            
            var response = WHEN_SendingCommonDataItem_as_Xml(commonDataItem);
            
            THEN_Http_Response_Is_Created(response);
            THEN_CommonDataItem_Matches(commonDataItem);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Should_accept_common_data_item_sent_for_replacement_as_json()
        {
            GIVEN_non_empty_CommonData();
            GIVEN_dataItem_with_key(ExpectedKey, ExpectedValue);
            var commonDataItem = GIVEN_CommonDataItem(ExpectedKey, ExpectedValue);
            
            var response = WHEN_SendingCommonDataItem_as_Json(commonDataItem);
            
            THEN_Http_Response_Is_Created(response);
            THEN_CommonDataItem_Matches(commonDataItem);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Should_accept_common_data_item_sent_for_replacement_as_xml()
        {
            GIVEN_non_empty_CommonData();
            GIVEN_dataItem_with_key(ExpectedKey, ExpectedValue);
            var commonDataItem = GIVEN_CommonDataItem(ExpectedKey, ExpectedValue) as CommonDataItem;
            
            var response = WHEN_SendingCommonDataItem_as_Xml(commonDataItem);
            
            THEN_Http_Response_Is_Created(response);
            THEN_CommonDataItem_Matches(commonDataItem);
        }
        // ============================================================================================================================
        
        void GIVEN_non_empty_CommonData()
        {
            TestRunQueue.TestRuns.First().Data.Data.Add("aaa", "bbb");
        }
        
        void GIVEN_dataItem_with_key(string key, string value)
        {
            TestRunQueue.TestRuns.First().Data.Data.Add(key, value);
        }
        
        ICommonDataItem GIVEN_CommonDataItem(string key, string value)
        {
            return new CommonDataItem { Key = key, Value = value };
        }
        
        BrowserResponse WHEN_SendingCommonDataItem_as_Json(ICommonDataItem dataItem)
        {
            var browser = TestFactory.GetBrowserForTestDataModule();
            var urn = UrlList.TestData_Root + "/" + _testRun.Id + UrlList.TestData_CommonData_forClient_relPath;
            return browser.Post(urn, with => {
                with.JsonBody<ICommonDataItem>(dataItem);
                with.Accept("application/json");
            });
        }
        
        BrowserResponse WHEN_SendingCommonDataItem_as_Xml(CommonDataItem dataItem)
        {
            var browser = TestFactory.GetBrowserForTestDataModule();
            var urn = UrlList.TestData_Root + "/" + _testRun.Id + UrlList.TestData_CommonData_forClient_relPath;
            return browser.Post(urn, with => {
                with.XMLBody<CommonDataItem>(dataItem);
                with.Accept("application/xml");
            });
        }
        
        void THEN_Http_Response_Is_Created(BrowserResponse response)
        {
            Xunit.Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }
        
        void THEN_CommonDataItem_Matches(ICommonDataItem dataItem)
        {
            Xunit.Assert.Equal(_testRun.Data.Data[dataItem.Key], dataItem.Value);
        }
    }
}
