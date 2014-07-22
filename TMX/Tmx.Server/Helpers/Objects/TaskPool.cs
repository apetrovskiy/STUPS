/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 7/22/2014
 * Time: 9:10 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Server
{
	using System;
	using System.Collections.Generic;
	using Tmx.Interfaces.Remoting;
	
	/// <summary>
	/// Description of TaskPool.
	/// </summary>
	public class TaskPool
	{
		public static List<ITestTask> Tasks = new List<ITestTask>();
	}
}
