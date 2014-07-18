/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 7/18/2014
 * Time: 11:37 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Client.Helpers
{
    using System;
    using RestSharp;
	using TMX.Interfaces;
	using Tmx.Server;
    
    /// <summary>
    /// Description of Registration.
    /// </summary>
    public class Registration
    {
        public int RegisterNewClientAndReturnClientId()
        {
			var client = new RestClient(ClientSettings.ServerUrl);
			var request = new RestRequest(UrnList.TestClients_Root + UrnList.TestClients_Clients, Method.POST);
			// request.AddParameter("name", "value");
			// request.AddUrlSegment("id", 123.ToString());
			request.AddHeader("header", "value");
			// request.AddBody(new TestResult { Name = "test result ...", Id = "111", TestScenarioId = "222", TestSuiteId = "333" });
			request.AddBody(
			    new TestClientInformation {
			        Hostname = Environment.MachineName,
			        Username = Environment.UserName,
			        UserDomainName = Environment.UserDomainName,
			        IsInteractive = Environment.UserInteractive
			    });
			// request.AddFile(path);
			var response = client.Execute(request);
			if (null == response)
				Console.WriteLine("null == response");
			if (null == response.Content)
				Console.WriteLine("null == response.Content");
			Console.WriteLine(response.StatusCode);
			var content = response.Content;
			Console.WriteLine("======= 01 =======");
			Console.WriteLine(content);
			Console.WriteLine("======= 02 =======");
			
			return 111;
        }
    }
}
