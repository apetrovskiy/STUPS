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
	using Tmx.Interfaces;
	using Tmx.Server;
    
    /// <summary>
    /// Description of Registration.
    /// </summary>
    public class Registration
    {
        public int SendRegistrationInfoAndGetClientId()
        {
			var client = new RestClient(ClientSettings.ServerUrl);
			var request = new RestRequest(UrnList.TestClients_Root + UrnList.TestClients_Clients, Method.POST);
			request.AddBody(
			    new TestClientInformation {
			        Hostname = Environment.MachineName,
			        Username = Environment.UserName,
			        UserDomainName = Environment.UserDomainName,
			        IsInteractive = Environment.UserInteractive
			    });
//			var response = client.Execute(request);
//			if (null == response)
//				Console.WriteLine("null == response");
//			if (null == response.Content)
//				Console.WriteLine("null == response.Content");
//			Console.WriteLine(response.StatusCode);
//			var content = response.Content;
//			Console.WriteLine("======= 01 =======");
//			Console.WriteLine(content);
//			Console.WriteLine("======= 02 =======");
			
			var registrationResponce = client.Execute(request);
			// registrationResponce.
			Console.WriteLine(registrationResponce);
			Console.WriteLine(registrationResponce.Content);
			Console.WriteLine(registrationResponce.ContentType);
			return 111;
        }
    }
}
