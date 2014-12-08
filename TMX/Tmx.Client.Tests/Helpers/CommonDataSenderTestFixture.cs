/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/7/2014
 * Time: 1:39 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Client.Tests.Helpers
{
    using System;
    using System.Net;
    using Spring.Http.Converters.Json;
    using Spring.IO;
    using Spring.Http;
    using Spring.Rest.Client;
    using Spring.Rest.Client.Testing;
    using NSubstitute;
    using Tmx.Core;
    using Tmx.Core.Types.Remoting;
    using Tmx.Interfaces.Remoting;
    using Tmx.Interfaces.Server;
    using Xunit;
    
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
        
        const string _baseUrl = "http://localhost:12340";
        MockRestServiceServer _mockRestServer;
        HttpHeaders _responseHeaders;
        RestTemplate _restTemplate;
        RestRequestCreator _restRequestCreator;
        
        ITestRun _testRun;
        
        public CommonDataSenderTestFixture()
        {
            prepareMocks();
        }
        
        [NUnit.Framework.SetUp]
        public void SetUp()
        {
            prepareMocks();
        }
        
        [NUnit.Framework.TearDown]
        public void TearDown()
        {
            _mockRestServer.Verify();
        }
        
        [NUnit.Framework.Test][Fact]
        public void Should_respond_Created_on_new_common_data_upload_as_json()
        {
            var url = GIVEN_url_to_testRun_data();
            _responseHeaders.Location = new Uri(_baseUrl + url);
            _mockRestServer.ExpectNewRequest()
                .AndExpectUri(_baseUrl + url)
                .AndExpectMethod(HttpMethod.POST)
                .AndRespondWith("", _responseHeaders, HttpStatusCode.Created, "");
            
            var commonDataSender = new CommonDataSender(_restRequestCreator);
            commonDataSender.Send(new CommonDataItem { Key = "aaa", Value = "bbb" });
        }
        
        [NUnit.Framework.Test][Fact]
        public void Should_respond_ExpectationFailed_on_common_data_update_as_json()
        {
            var url = GIVEN_url_to_testRun_data();
            _responseHeaders.Location = new Uri(_baseUrl + url);
            _mockRestServer.ExpectNewRequest()
                .AndExpectUri(_baseUrl + url)
                .AndExpectMethod(HttpMethod.POST)
                .AndRespondWith("", _responseHeaders, HttpStatusCode.Created, "");
            _mockRestServer.ExpectNewRequest()
                .AndExpectUri(_baseUrl + url)
                .AndExpectMethod(HttpMethod.POST)
                .AndRespondWith("", _responseHeaders, HttpStatusCode.Created, "");
            
            var commonDataSender = new CommonDataSender(_restRequestCreator);
            commonDataSender.Send(new CommonDataItem { Key = "aaa", Value = "bbb" });
            commonDataSender.Send(new CommonDataItem { Key = "aaa", Value = "bbb" });
        }
        
        [NUnit.Framework.Test][Fact]
        public void Should_respond_Ok_on_getting_common_data_as_json()
        {
            var url = GIVEN_url_to_testRun_data();
            _responseHeaders.Location = new Uri(_baseUrl + url);
            _mockRestServer.ExpectNewRequest()
                .AndExpectUri(_baseUrl + url)
                .AndExpectMethod(HttpMethod.GET)
                .AndRespondWith("", _responseHeaders, HttpStatusCode.OK, "");
            
            var commonDataLoader = new CommonDataLoader(_restRequestCreator);
            commonDataLoader.Load();
        }

        string GIVEN_url_to_testRun_data()
        {
            _testRun = new TestRun();
            ClientSettings.Instance.CurrentClient = new TestClient {
                TestRunId = _testRun.Id
            };
            return UrlList.TestData_Root + "/" + _testRun.Id + UrlList.TestData_CommonData_forClient_relPath;
        }
        void prepareMocks()
        {
            _restTemplate = new RestTemplate(_baseUrl);
            _restTemplate.MessageConverters.Add(new NJsonHttpMessageConverter());
            _mockRestServer = MockRestServiceServer.CreateServer(_restTemplate);
            _responseHeaders = new HttpHeaders();
            _responseHeaders.ContentType = new MediaType("application", "json");
            ClientSettings.Instance.ServerUrl = _baseUrl;
            _restRequestCreator = new RestRequestCreator();
            _restRequestCreator.SetRestTemplate(_restTemplate);
        }
    }
}
