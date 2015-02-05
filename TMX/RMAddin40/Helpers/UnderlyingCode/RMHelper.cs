/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/1/2013
 * Time: 1:23 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
    using System;
    using System.Management.Automation;
    using Redmine.Net.Api;
    using Redmine.Net.Api.Types;
    
    /// <summary>
    /// Description of RMHelper.
    /// </summary>
    public static class RMHelper
    {
        static RMHelper()
        {
        }
        
        public static void ConnectRMServer(RMConnectCmdletBase cmdlet)
        {
//            Redmine.Net.Api.RedmineWebClient client =
//                new RedmineWebClient();
//            client.
                
            string host = "";
            string apiKey = "";

            var manager = new RedmineManager(host, apiKey);

//            var parameters = new NameValueCollection {{"status_id", "*"}};
//            foreach (var issue in manager.GetObjectList<Issue>(parameters))
//            {
//                Console.WriteLine("#{0}: {1}", issue.Id, issue.Subject);
//            }
//
//            //Create a issue.
//            var newIssue = new Issue { Subject = "test", Project = new IdentifiableName{Id =  1}};
//            manager.CreateObject(newIssue);
        }
    }
}
