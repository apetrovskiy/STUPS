/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/9/2012
 * Time: 6:57 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of TFSrvGetTestSuiteCommand.
    /// </summary>
    internal class TFSrvGetTestSuiteCommand : TFSrvCommand
    {
        internal TFSrvGetTestSuiteCommand(TFSCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            TFHelper.GetTestSuite(this.Cmdlet, this.Cmdlet.Name);
        }
    }
}
