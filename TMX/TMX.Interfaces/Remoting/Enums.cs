/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/13/2014
 * Time: 9:35 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX.Interfaces.Remoting
{
	public enum TestActivityStatuses
	{
		New = 0,
		Accepted = 1,
		CompletedSuccessfully = 2,
		Failed = 3
	}
	
	public enum TestActivityTypes
	{
	    Inline = 0,
	    RemoteApp = 1,
	    PsRemoting = 2,
	    Ssh = 10
	}
}