/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 7/25/2014
 * Time: 9:04 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Client
{
    using System;
	using System.Net;
    using RestSharp;
	using TMX.Interfaces.Exceptions;
	using Tmx.Interfaces;
	using Tmx.Interfaces.Remoting;
	using Tmx.Server;
    
    /// <summary>
    /// Description of RestRequestCreator.
    /// </summary>
    public class RestRequestCreator
    {
        public virtual RestClient RestClient { get; set; }
        
        public virtual RestRequest GetRestRequest(string url, Method method)
        {
            RestClient = new RestClient(ClientSettings.ServerUrl);
            return new RestRequest(url, method);
        }
    }
}
