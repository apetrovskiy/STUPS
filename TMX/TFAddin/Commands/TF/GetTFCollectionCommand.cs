/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/9/2012
 * Time: 6:51 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of GetTFCollectionCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "TFCollection")]
    public class GetTFCollectionCommand : TFCollectionCmdletBase
    {
        public GetTFCollectionCommand()
        {
        }
        
        protected override void BeginProcessing()
        {
            this.CheckCmdletParameters();
            
            TFSrvGetCollectionCommand command =
                new TFSrvGetCollectionCommand(this);
            command.Execute();
        }
    }
}
