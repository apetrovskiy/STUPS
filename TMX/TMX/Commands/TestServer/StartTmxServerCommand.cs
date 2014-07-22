/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/14/2014
 * Time: 9:26 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

//namespace Tmx.Commands
//{
//    using System;
//    using System.Management.Automation;
//    
//    /// <summary>
//    /// Description of StartTmxServerCommand.
//    /// </summary>
//    [Cmdlet(VerbsLifecycle.Start, "TmxServer")]
//    public class StartTmxServerCommand : CommonCmdletBase
//    {
//    	public StartTmxServerCommand()
//    	{
//    		this.Port = 12340;
//    	}
//    	
//    	[Parameter(Mandatory = false,
//    	           Position = 0)]
//    	public int Port { get; set; }
//    	
//        protected override void BeginProcessing()
//        {
//        	var command = new StartServerCommand(this);
//        	command.Execute();
//        }
//    }
//}
