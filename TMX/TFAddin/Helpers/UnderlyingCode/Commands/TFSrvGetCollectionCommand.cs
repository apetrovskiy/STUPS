/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/9/2012
 * Time: 6:55 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
    using System;
    using System.Management.Automation;
    using Microsoft.TeamFoundation.Client;
    using Microsoft.TeamFoundation.TestManagement.Client;
    
    /// <summary>
    /// Description of TFSrvGetCollectionCommand.
    /// </summary>
    internal class TFSrvGetCollectionCommand : TFSrvCommand
    {
        internal TFSrvGetCollectionCommand(TFSCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            var cmdlet = (TFCollectionCmdletBase)Cmdlet;

            TFHelper.OpenProjectCollection(
                cmdlet,
                cmdlet.Name);
        }
    }
}
