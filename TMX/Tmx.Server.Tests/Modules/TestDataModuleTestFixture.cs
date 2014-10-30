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
    using System;
    using System.Management.Automation;
    using System.Linq;
    using Nancy;
    using Nancy.Testing;
    using MbUnit.Framework;
    using NUnit.Framework;
    using Tmx.Client;
    using Tmx.Core.Types.Remoting;
	using Tmx.Interfaces.Internal;
    using Tmx.Interfaces.Remoting;
	using Tmx.Interfaces.Server;
	using Tmx.Core;
	using Tmx.Interfaces;
	using Tmx.Interfaces.TestStructure;
	using Tmx.Server.Modules;
    using Xunit;
    using PSTestLib;
    
    /// <summary>
    /// Description of TestDataModuleTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture]
    public class TestDataModuleTestFixture
    {
	    ITestWorkflow _workflow;
	    ITestRun _testRun;
        
        public TestDataModuleTestFixture()
        {
            TestSettings.PrepareModuleTests();
		    TestFactory.GetTestRunWithStatus(TestRunStatuses.Running);
		    _workflow = WorkflowCollection.Workflows.First();
		    _testRun = TestRunQueue.TestRuns.First();
		    // ClientSettings.Instance.CurrentTask = new TestTask { TestRunId = _testRun };
        }
        
    	[MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
    	public void SetUp()
    	{
    	    TestSettings.PrepareModuleTests();
		    TestFactory.GetTestRunWithStatus(TestRunStatuses.Running);
		    _workflow = WorkflowCollection.Workflows.First();
		    _testRun = TestRunQueue.TestRuns.First();
		    // ClientSettings.Instance.CurrentTask = new TestTask { TestRunId = Guid.NewGuid() };
    	}
    	
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Should_accept_common_data_item_sent_to_empty_CommonData_as_json()
        {
            const string expectedKey = "a1";
            const string expectedValue = "b1";
            var commonDataItem = GIVEN_CommonDataItem(expectedKey, expectedValue);
            
            var response = WHEN_SendingCommonDataItem_as_Json(commonDataItem);
            
            THEN_Http_Response_Is_Created(response);
            THEN_CommonDataItem_Matches(commonDataItem);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Should_accept_common_data_item_sent_to_empty_CommonData_as_xml()
        {
            const string expectedKey = "a1";
            const string expectedValue = "b1";
            var commonDataItem = GIVEN_CommonDataItem(expectedKey, expectedValue) as CommonDataItem;
            
            var response = WHEN_SendingCommonDataItem_as_Xml(commonDataItem);
            
            THEN_Http_Response_Is_Created(response);
            THEN_CommonDataItem_Matches(commonDataItem);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Should_accept_common_data_item_sent_to_non_empty_CommonData_as_json()
        {
            GIVEN_non_empty_CommonData();
            const string expectedKey = "a1";
            const string expectedValue = "b1";
            var commonDataItem = GIVEN_CommonDataItem(expectedKey, expectedValue);
            
            var response = WHEN_SendingCommonDataItem_as_Json(commonDataItem);
            
            THEN_Http_Response_Is_Created(response);
            THEN_CommonDataItem_Matches(commonDataItem);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Should_accept_common_data_item_sent_to_non_empty_CommonData_as_xml()
        {
            GIVEN_non_empty_CommonData();
            const string expectedKey = "a1";
            const string expectedValue = "b1";
            var commonDataItem = GIVEN_CommonDataItem(expectedKey, expectedValue) as CommonDataItem;
            
            var response = WHEN_SendingCommonDataItem_as_Xml(commonDataItem);
            
            THEN_Http_Response_Is_Created(response);
            THEN_CommonDataItem_Matches(commonDataItem);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Should_accept_common_data_item_sent_for_replacement_as_json()
        {
            GIVEN_non_empty_CommonData();
            const string expectedKey = "a1";
            const string expectedValue = "b1";
            GIVEN_dataItem_with_key(expectedKey, expectedValue);
            var commonDataItem = GIVEN_CommonDataItem(expectedKey, expectedValue);
            
            var response = WHEN_SendingCommonDataItem_as_Json(commonDataItem);
            
            THEN_Http_Response_Is_Created(response);
            THEN_CommonDataItem_Matches(commonDataItem);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Should_accept_common_data_item_sent_for_replacement_as_xml()
        {
            GIVEN_non_empty_CommonData();
            const string expectedKey = "a1";
            const string expectedValue = "b1";
            GIVEN_dataItem_with_key(expectedKey, expectedValue);
            var commonDataItem = GIVEN_CommonDataItem(expectedKey, expectedValue) as CommonDataItem;
            
            var response = WHEN_SendingCommonDataItem_as_Xml(commonDataItem);
            
            THEN_Http_Response_Is_Created(response);
            THEN_CommonDataItem_Matches(commonDataItem);
        }
    	// ============================================================================================================================
    	
    	void GIVEN_non_empty_CommonData()
    	{
    	    // CommonData.Data.Add("aaa", "bbb");
    	    TestRunQueue.TestRuns.First().Data.Data.Add("aaa", "bbb");
    	}
    	
    	void GIVEN_dataItem_with_key(string key, string value)
    	{
    	    // CommonData.Data.Add(key, value);
    	    TestRunQueue.TestRuns.First().Data.Data.Add(key, value);
    	}
    	
    	ICommonDataItem GIVEN_CommonDataItem(string key, string value)
    	{
    	    return new CommonDataItem { Key = key, Value = value };
    	}
    	
        BrowserResponse WHEN_SendingCommonDataItem_as_Json(ICommonDataItem dataItem)
        {
            var browser = TestFactory.GetBrowserForTestDataModule();
            // var urn = UrnList.TestData_Root + "/" + ClientSettings.Instance.CurrentTask.TestRunId + UrnList.TestData_CommonData_forClient_relPath;
            var urn = UrnList.TestData_Root + "/" + _testRun.Id + UrnList.TestData_CommonData_forClient_relPath;
            // return browser.Post(UrnList.CommonDataLoadingPoint_absPath, with => {
            return browser.Post(urn, with => {
                with.JsonBody<ICommonDataItem>(dataItem);
                with.Accept("application/json");
            });
        }
        
        BrowserResponse WHEN_SendingCommonDataItem_as_Xml(CommonDataItem dataItem)
        {
            var browser = TestFactory.GetBrowserForTestDataModule();
            // var urn = UrnList.TestData_Root + "/" + ClientSettings.Instance.CurrentTask.TestRunId + UrnList.TestData_CommonData_forClient_relPath;
            var urn = UrnList.TestData_Root + "/" + _testRun.Id + UrnList.TestData_CommonData_forClient_relPath;
            // return browser.Post(UrnList.CommonDataLoadingPoint_absPath, with => {
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
            // Xunit.Assert.Equal(CommonData.Data[dataItem.Key], dataItem.Value);
            // Xunit.Assert.Equal(TestRunQueue.TestRuns.First().Data.Data[dataItem.Key], dataItem.Value);
            Xunit.Assert.Equal(_testRun.Data.Data[dataItem.Key], dataItem.Value);
        }
    }
}
