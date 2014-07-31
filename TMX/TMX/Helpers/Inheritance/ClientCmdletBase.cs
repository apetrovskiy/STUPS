/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/24/2014
 * Time: 3:15 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
	using System;
	using System.Management.Automation;
	
	/// <summary>
	/// Description of ClientCmdletBase.
	/// </summary>
	public class ClientCmdletBase : CommonCmdletBase
	{
        #region Parameters
        [Parameter(Mandatory = false)]
        internal new string Name { get; set; }
        
        [Parameter(Mandatory = false)]
        internal new string Id { get; set; }
        
        [Parameter(Mandatory = false)]
        internal new string TestPlatformId { get; set; }
        #endregion Parameters
	}
}
