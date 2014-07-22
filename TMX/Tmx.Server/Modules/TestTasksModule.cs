/*
 * Created by SharpDevelop.
<<<<<<< HEAD
 * User: alexa_000
 * Date: 7/21/2014
 * Time: 10:16 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Nancy;

namespace Tmx.Server.Modules
{
	/// <summary>
	/// Description of TestTasksModule.
	/// </summary>
	public class TestTasksModule : NancyModule
	{
		public TestTasksModule() : base("/tasks")
		{
			
		}
	}
=======
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
>>>>>>> 48b832a27276939de00d70f366cdb7ac4f26d8c3
}
