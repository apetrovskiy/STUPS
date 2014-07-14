/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 7/14/2014
 * Time: 9:27 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Server.Commands
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of StopTmxServerCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Stop, "TmxServer")]
    public class StopTmxServerCommand : PSCmdlet
    {
        protected override void BeginProcessing()
        {
            Control.Stop();
        }
    }
}
