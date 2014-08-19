/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/25/2014
 * Time: 9:04 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Client
{
    using System;
    using RestSharp;
    
    /// <summary>
    /// Description of RestRequestCreator.
    /// </summary>
    public class RestRequestCreator
    {
        public virtual RestClient RestClient { get; set; }
        
        public virtual RestRequest GetRestRequest(string url, Method method)
        {
            // RestClient = new RestClient(ClientSettings.ServerUrl);
            var clientSettings = ClientSettings.Instance;
            RestClient = new RestClient(clientSettings.ServerUrl);
            
            return new RestRequest(url, method);
        }
    }
}
