/*
 * Created by SharpDevelop.
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
}
