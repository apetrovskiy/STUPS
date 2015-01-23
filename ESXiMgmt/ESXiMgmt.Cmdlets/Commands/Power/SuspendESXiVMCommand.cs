/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 4/1/2012
 * Time: 10:47 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EsxiMgmt.Cmdlets.Commands
{
    using System;
    using System.Management.Automation;
        
    /// <summary>
    /// Description of SuspendESXiVMCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Suspend, "ESXiVM")]
    public class SuspendESXiVMCommand : PowerCmdletBase
    {
        public SuspendESXiVMCommand()
        {
        }
    }
}
