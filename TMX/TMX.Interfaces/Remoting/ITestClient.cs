/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/8/2014
 * Time: 8:39 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Interfaces.Remoting
{
	using Tmx.Interfaces.Internal;
	
	/// <summary>
	/// Description of ITestClient.
	/// </summary>
	public interface ITestClient : ISystemInfo
	{
		int Id { get; set; }
		TestClientStatuses Status { get; set; }
		// 20141003
		int TaskId { get; set; }
		string TaskName { get; set; }
		string DetailedStatus { get; set; }
	}
}
