/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 7/14/2014
 * Time: 9:26 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Server.Commands
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of StartTmxServerCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Start, "TmxServer")]
    public class StartTmxServerCommand : PSCmdlet
    {
        protected override void BeginProcessing()
        {
            // Control.Start(@"http://localhost:13001");
            Control.Start(@"http://localhost:12340");
        }
    }
}
