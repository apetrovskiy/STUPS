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
    using Nancy;
    using Nancy.Testing;
    using MbUnit.Framework;
    using NUnit.Framework;
	using TMX.Interfaces.Internal;
    using TMX.Interfaces.Remoting;
	using TMX.Interfaces.Server;
	using Tmx.Core;
	using Tmx.Interfaces;
	using Tmx.Interfaces.Remoting;
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
        public TestDataModuleTestFixture()
        {
            TestSettings.PrepareModuleTests();
        }
        
    	[MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
    	public void SetUp()
    	{
    	    TestSettings.PrepareModuleTests();
    	}
    	
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Should_accept_common_data_item_sent_to_empty_CommonData()
        {
            const string expectedKey = "a1";
            const string expectedValue = "b1";
            var commonDataItem = GIVEN_CommonDataItem(expectedKey, expectedValue);
            
            var response = WHEN_SendingCommonDataItem(commonDataItem);
            
            THEN_Http_Response_Is_Created(response);
            THEN_CommonDataItem_Matches(commonDataItem);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Should_accept_common_data_item_sent_to_non_empty_CommonData()
        {
            GIVEN_non_empty_CommonData();
            const string expectedKey = "a1";
            const string expectedValue = "b1";
            var commonDataItem = GIVEN_CommonDataItem(expectedKey, expectedValue);
            
            var response = WHEN_SendingCommonDataItem(commonDataItem);
            
            THEN_Http_Response_Is_Created(response);
            THEN_CommonDataItem_Matches(commonDataItem);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Should_accept_common_data_item_sent_for_replacement()
        {
            GIVEN_non_empty_CommonData();
            const string expectedKey = "a1";
            const string expectedValue = "b1";
            GIVEN_dataItem_with_key(expectedKey, expectedValue);
            var commonDataItem = GIVEN_CommonDataItem(expectedKey, expectedValue);
            
            var response = WHEN_SendingCommonDataItem(commonDataItem);
            
            THEN_Http_Response_Is_Created(response);
            THEN_CommonDataItem_Matches(commonDataItem);
        }
    	// ============================================================================================================================
    	
    	void GIVEN_non_empty_CommonData()
    	{
    	    CommonData.Data.Add("aaa", "bbb");
    	}
    	
    	void GIVEN_dataItem_with_key(string key, string value)
    	{
    	    CommonData.Data.Add(key, value);
    	}
    	
    	ICommonDataItem GIVEN_CommonDataItem(string key, string value)
    	{
    	    return new CommonDataItem { Key = key, Value = value };
    	}
    	
        BrowserResponse WHEN_SendingCommonDataItem(ICommonDataItem dataItem)
        {
            var browser = TestFactory.GetBrowserForTestDataModule();
            return browser.Post(UrnList.CommonDataLoadingPoint, with => with.JsonBody<ICommonDataItem>(dataItem));
        }
        
        void THEN_Http_Response_Is_Created(BrowserResponse response)
        {
            Xunit.Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }
        
        void THEN_CommonDataItem_Matches(ICommonDataItem dataItem)
        {
            Xunit.Assert.Equal(CommonData.Data[dataItem.Key], dataItem.Value);
        }
    }
}
