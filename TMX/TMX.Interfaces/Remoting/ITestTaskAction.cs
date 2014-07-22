/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/10/2014
 * Time: 6:19 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Interfaces.Remoting
{
	using System.Collections.Generic;
	
	/// <summary>
	/// Description of ITestTaskAction.
	/// </summary>
	public interface ITestTaskAction
	{
		string Code { get; set; }
		Dictionary<string, object> Parameters { get; set; }
	}
}
