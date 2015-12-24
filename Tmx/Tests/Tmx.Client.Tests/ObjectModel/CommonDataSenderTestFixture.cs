/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/7/2014
 * Time: 1:39 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Client.Tests.ObjectModel
{
    using System;
    using System.Net;
    using Spring.Http;
    using Spring.Http.Converters.Json;
    using Spring.Rest.Client;
    using Spring.Rest.Client.Testing;
    using Core;
    using Core.Types.Remoting;
    using Interfaces.Remoting;
    using Interfaces.Server;
    using Xunit;
    using Client;
    using Core.Proxy;
    using Library.Helpers;
    using Library.ObjectModel;
    
    /// <summary>
    /// Description of CommonDataSenderTestFixture.
    /// </summary>
    [NUnit.Framework.TestFixture]
    public class CommonDataSenderTestFixture
    {
        /*
Create a MockRestServiceServer instance by calling MockRestServiceServer.CreateServer(RestTemplate) method with the RestTemplate to test.
Set up request expectation by calling MockRestServiceServer.ExpectNewRequest() method. 
More request expectations can be set up by chaining IRequestActions.AndExpect(RequestMatcher) calls, possibly by using the default method extensions provided.
Create an appropriate response message by calling IRequestActions.AndRespond(ResponseCreator) method, possibly by using the default method extensions provided.
Call MockRestServiceServer.Verify() method.
        */
        
        const string BaseUrl = "http://localhost:12340";
        MockRestServiceServer _mockRestServer;
        HttpHeaders _responseHeaders;
        RestTemplate _restTemplate;
        RestRequestCreator _restRequestCreator;
        
        ITestRun _testRun;
        
        public CommonDataSenderTestFixture()
        {
            PrepareMocks();
        }
        
        [NUnit.Framework.SetUp]
        public void SetUp()
        {
            PrepareMocks();
        }
        
        [NUnit.Framework.TearDown]
        public void TearDown()
        {
            _mockRestServer.Verify();
        }
        
        [NUnit.Framework.Test][Fact]
        public void Should_respond_Created_on_new_common_data_upload_as_json()
        {
            const string expectedKey = "aaa";
            const string expectedValue = "bbb";
            var url = GIVEN_url_to_testRun_data();
            _responseHeaders.Location = new Uri(BaseUrl + url);
            _mockRestServer.ExpectNewRequest()
                .AndExpectUri(BaseUrl + url)
                .AndExpectMethod(HttpMethod.POST)
                .AndExpectBodyContains(expectedKey)
                .AndExpectBodyContains(expectedValue)
                .AndRespondWith("", _responseHeaders, HttpStatusCode.Created, "");
            
            var commonDataSender = ProxyFactory.Get<CommonDataSender>();
            commonDataSender.Send(new CommonDataItem { Key = expectedKey, Value = expectedValue });
        }
        
        [NUnit.Framework.Test][Fact]
        public void Should_respond_ExpectationFailed_on_common_data_update_as_json()
        {
            const string expectedKey = "aaa";
            const string expectedValue = "bbb";
            var url = GIVEN_url_to_testRun_data();
            _responseHeaders.Location = new Uri(BaseUrl + url);
            _mockRestServer.ExpectNewRequest()
                .AndExpectUri(BaseUrl + url)
                .AndExpectMethod(HttpMethod.POST)
                .AndExpectBodyContains(expectedKey)
                .AndExpectBodyContains(expectedValue)
                .AndRespondWith("", _responseHeaders, HttpStatusCode.Created, "");
            _mockRestServer.ExpectNewRequest()
                .AndExpectUri(BaseUrl + url)
                .AndExpectMethod(HttpMethod.POST)
                .AndExpectBodyContains(expectedKey)
                .AndExpectBodyContains(expectedValue)
                .AndRespondWith("", _responseHeaders, HttpStatusCode.Created, "");
            
            var commonDataSender = ProxyFactory.Get<CommonDataSender>();
            commonDataSender.Send(new CommonDataItem { Key = expectedKey, Value = expectedValue });
            commonDataSender.Send(new CommonDataItem { Key = expectedKey, Value = expectedValue });
        }
        
        [NUnit.Framework.Test][Fact]
        public void Should_respond_Ok_on_getting_common_data_as_json()
        {
            var url = GIVEN_url_to_testRun_data();
            _responseHeaders.Location = new Uri(BaseUrl + url);
            _mockRestServer.ExpectNewRequest()
                .AndExpectUri(BaseUrl + url)
                .AndExpectMethod(HttpMethod.GET)
                .AndRespondWith("{ \"Key\":\"aaa\",\"Value\":\"bbb\" }", _responseHeaders, HttpStatusCode.OK, "");
            
            var commonDataLoader = ProxyFactory.Get<CommonDataLoader>();
            var resultDictionary = commonDataLoader.Load();
            
            Assert.Equal("aaa", resultDictionary["Key"]);
            Assert.Equal("bbb", resultDictionary["Value"]);
        }
        
        string GIVEN_url_to_testRun_data()
        {
            _testRun = new TestRun();
            ClientSettings.Instance.CurrentClient = new TestClient {
                TestRunId = _testRun.Id
            };
            return UrlList.TestData_Root + "/" + _testRun.Id + UrlList.TestData_CommonData_forClient_relPath;
        }
        
        void PrepareMocks()
        {
            _restTemplate = new RestTemplate(BaseUrl);
            _restTemplate.MessageConverters.Add(new NJsonHttpMessageConverter());
            _mockRestServer = MockRestServiceServer.CreateServer(_restTemplate);
            _responseHeaders = new HttpHeaders {ContentType = new MediaType("application", "json")};
            ClientSettings.Instance.ServerUrl = BaseUrl;
            _restRequestCreator = new RestRequestCreator();
            _restRequestCreator.SetRestTemplate(_restTemplate);
            RestRequestFactory.RestRequestCreator = _restRequestCreator;
        }
    }
}
