/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/29/2014
 * Time: 8:27 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Client
{
    using System;
    using System.Net;
    using Spring.Rest.Client;
    using Tmx.Core.Types.Remoting;
    using Tmx.Interfaces.Remoting;
    using Tmx.Interfaces.Server;
    
    /// <summary>
    /// Description of TestRunCreator.
    /// </summary>
    public class TestRunCreator
    {
        readonly IRestOperations _restTemplate;
        
        public TestRunCreator(RestRequestCreator requestCreator)
        {
            _restTemplate = requestCreator.GetRestTemplate();
        }
        
        public bool CreateTestRun(string workflowName, TestRunStatuses status, string name)
        {
            var testRunCommand = new TestRunCommand {
                Name = name,
                Status = status,
                WorkflowName = workflowName
            };
            var creatingTestRunResponse = _restTemplate.PostForMessage(UrnList.TestRunsControlPoint_absPath, testRunCommand);
            return HttpStatusCode.Created == creatingTestRunResponse.StatusCode;
        }
    }
}
