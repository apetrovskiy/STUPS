/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 7/19/2014
 * Time: 3:01 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Server.Modules
{
    using System;
	using Nancy;
    
    /// <summary>
    /// Description of TestTasksModule.
    /// </summary>
    public class TestTasksModule : NancyModule
    {
        public TestTasksModule() : base(UrnList.TestTasks_Root)
        {
            Get[UrnList.TestTasks_Current] = parameters => {
                // something to identify the client
                
                return HttpStatusCode.OK;
            };
        }
    }
}
