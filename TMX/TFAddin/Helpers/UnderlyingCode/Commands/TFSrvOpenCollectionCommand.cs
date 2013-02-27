/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/9/2012
 * Time: 6:56 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of TFSrvOpenCollectionCommand.
    /// </summary>
    internal class TFSrvOpenCollectionCommand : TFSrvCommand
    {
        internal TFSrvOpenCollectionCommand(TFSCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            TFHelper.OpenProjectCollection(this.Cmdlet, this.Cmdlet.Name);
        }
    }
}
