/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 8/28/2014
 * Time: 4:55 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Client
{
	using System;
	using System.Collections.Generic;
	using System.Net;
	using System.Xml;
	using System.Xml.Linq;
	using Spring.Http;
	using Spring.Http.Converters;
	using Spring.Http.Converters.Xml;
	using Spring.Rest.Client;
	using TMX.Interfaces;
	using TMX.Interfaces.Exceptions;
	using TMX.Interfaces.Server;
	using Tmx.Interfaces.TestStructure;
//	using Tmx.Interfaces.Remoting;
	
    /// <summary>
    /// Description of TestResultsSender.
    /// </summary>
    public class TestResultsSender
    {
	    volatile RestTemplate _restTemplate;
	    
	    public TestResultsSender(RestRequestCreator requestCreator)
	    {
	    	_restTemplate = requestCreator.GetRestTemplate(string.Empty);
	    }
	    
	    public bool SendTestResults()
	    {
//Console.WriteLine("sending test results 000001");
	        var document =
	            TmxHelper.GetTestResultsAsXdocument(
	            // TmxHelper.GetTestResultsAsXelement(
	                new SearchCmdletBaseDataObject {
	                    FilterAll = true
	                });
//Console.WriteLine("sending test results 000002");
//if (null == document) {
//    Console.WriteLine("null == document");
//} else {
//    Console.WriteLine("null != document");
//    Console.WriteLine(document.GetType().Name);
//    Console.WriteLine(document.FirstNode);
//}
			try {
Console.WriteLine("sending test results 000003");
			    // var response = _restTemplate.PostForMessage<XDocument>(UrnList.TestStructure_Root + UrnList.TestStructure_AllResults, document);
			    // var response = _restTemplate.PostForMessage<XElement>(UrnList.TestStructure_Root + UrnList.TestStructure_AllResults, document);
			    // var response = _restTemplate.PostForMessage(UrnList.TestStructure_Root + UrnList.TestStructure_AllResults, document);
			    // var response = _restTemplate.PostForMessage(UrnList.TestStructure_Root + UrnList.TestStructure_AllResults, document.Root);
//			    _restTemplate.MessageConverters.Clear();
//			    // _restTemplate.MessageConverters.Add(new XmlSerializableHttpMessageConverter());
//			    // var converter = new XmlDocumentHttpMessageConverter();
//			    // var converter = new XmlSerializableHttpMessageConverter();
//			    var converter = new ResourceHttpMessageConverter();
//			    // converter.SupportedMediaTypes.Add(new MediaType("application/xml"));
//			    _restTemplate.MessageConverters.Add(converter);
			    // _restTemplate.MessageConverters.Add(new XElementHttpMessageConverter());
			    // var response = _restTemplate.PostForMessage<XElement>(UrnList.TestStructure_Root + UrnList.TestStructure_AllResults, document);
				// return HttpStatusCode.Created == response.StatusCode;
				// var entity = new HttpEntity(document);
//Console.WriteLine("sending test results 000004");
//				// var response = _restTemplate.PostForMessage<XDocument>(UrnList.TestStructure_Root + UrnList.TestStructure_AllResults, entity);
//				// var response = _restTemplate.PostForMessage<XDocument>(UrnList.TestStructure_Root + UrnList.TestStructure_AllResults, document);
//				var newDoc = new XmlDocument();
//				newDoc.LoadXml(document.FirstNode.ToString());
//Console.WriteLine(newDoc.InnerText);
//Console.WriteLine(newDoc.InnerXml);
//                var response = _restTemplate.PostForMessage<XmlDocument>(UrnList.TestStructure_Root + UrnList.TestStructure_AllResults, newDoc);
//Console.WriteLine("sending test results 000005");
                var response = _restTemplate.PostForMessage<List<ITestSuite>>(UrnList.TestStructure_Root + UrnList.TestStructure_AllResults, TestData.TestSuites);
				return HttpStatusCode.Created == response.StatusCode;
			    
//			var registrationResponse = _restTemplate.PostForMessage<TestClient>(UrnList.TestClientRegistrationPoint, getNewTestClient(customClientString));
//			if (HttpStatusCode.Created == registrationResponse.StatusCode)
//				return registrationResponse.Body.Id;
//			throw new Exception("Failed to register a client. "+ registrationResponse.StatusCode); // TODO: new type!
			    
			}
            catch (Exception eSendingTestResults) {
			    throw new SendingTestResultsException("Failed to send test results. " + eSendingTestResults.Message);
			}
	    }
    }
}
