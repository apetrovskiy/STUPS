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
    using Spring.IO;
    using Spring.Http;
    using Spring.Rest.Client;
    using Spring.Rest.Client.Testing;
    using NSubstitute;
    using Tmx.Core;
    using Tmx.Interfaces.Server;
    using Xunit;
    
    /// <summary>
    /// Description of CommonDataSenderTestFixture.
    /// </summary>
    [NUnit.Framework.TestFixture]
    public class CommonDataSenderTestFixture
    {
        const string _baseUrl = "http://localhost:12340";
        MockRestServiceServer _restServer;
        HttpHeaders _responseHeaders;
        RestTemplate _restTemplate;
        RestRequestCreator _restRequestCreator;
        
        public CommonDataSenderTestFixture()
        {
            _restTemplate = new RestTemplate(_baseUrl);
            _restServer = MockRestServiceServer.CreateServer(_restTemplate);
            _responseHeaders = new HttpHeaders();
            _responseHeaders.ContentType = new MediaType("application", "json");
            ClientSettings.Instance.ServerUrl = _baseUrl;
            _restRequestCreator = new RestRequestCreator();
            _restRequestCreator.SetRestTemplate(_restTemplate);
        }
        
        [NUnit.Framework.SetUp]
        public void SetUp()
        {
            _restTemplate = new RestTemplate(_baseUrl);
            _restServer = MockRestServiceServer.CreateServer(_restTemplate);
            _responseHeaders = new HttpHeaders();
            _responseHeaders.ContentType = new MediaType("application", "json");
            ClientSettings.Instance.ServerUrl = _baseUrl;
            _restRequestCreator = new RestRequestCreator();
            _restRequestCreator.SetRestTemplate(_restTemplate);
        }
        
        [NUnit.Framework.TearDown]
        public void TearDown()
        {
            _restServer.Verify();
        }
        
        [NUnit.Framework.Test][Fact]
        public void Should_respond_Created_on_new_common_data_upload_as_json()
        {
            // var urn = UrnList.TestData_Root + "/" + ClientSettings.Instance.CurrentClient.TestRunId + UrnList.TestData_CommonData_forClient_relPath;
            var urn = UrnList.TestData_Root + "/" + Guid.NewGuid() + UrnList.TestData_CommonData_forClient_relPath; // ??
            // _responseHeaders.Location = new Uri(_baseUrl + UrnList.CommonDataLoadingPoint_absPath);
            _responseHeaders.Location = new Uri(_baseUrl + urn);
            _restServer.ExpectNewRequest()
                // .AndExpectUri(_baseUrl + UrnList.CommonDataLoadingPoint_absPath)
                .AndExpectUri(_baseUrl + urn)
                .AndExpectMethod(HttpMethod.POST)
                .AndRespondWith("", _responseHeaders, HttpStatusCode.Created, "");
            
            var commonDataSender = new CommonDataSender(_restRequestCreator);
            commonDataSender.Send(new CommonDataItem { Key = "aaa", Value = "bbb" });
        }
        
        [NUnit.Framework.Test][Fact]
        public void Should_respond_Ok_on_getting_common_data_as_json()
        {
            // var urn = UrnList.TestData_Root + "/" + ClientSettings.Instance.CurrentClient.TestRunId + UrnList.TestData_CommonData_forClient_relPath;
            var urn = UrnList.TestData_Root + "/" + Guid.NewGuid() + UrnList.TestData_CommonData_forClient_relPath; // ??
            // _responseHeaders.Location = new Uri(_baseUrl + UrnList.CommonDataLoadingPoint_absPath);
            _responseHeaders.Location = new Uri(_baseUrl + urn);
            _restServer.ExpectNewRequest()
                // .AndExpectUri(_baseUrl + UrnList.CommonDataLoadingPoint_absPath)
                .AndExpectUri(_baseUrl + urn)
                .AndExpectMethod(HttpMethod.GET)
                .AndRespondWith("", _responseHeaders, HttpStatusCode.OK, "");
            
            var commonDataLoader = new CommonDataLoader(_restRequestCreator);
            commonDataLoader.Load();
        }
    }
}
