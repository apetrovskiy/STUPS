/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/18/2012
 * Time: 5:24 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Commands
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of NewBDDFeatureCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "BDDFeature")]
    public class NewBDDFeatureCommand : BDDFeatureCmdletBase
    {
        public NewBDDFeatureCommand()
        {
        }
        
        protected override void BeginProcessing()
        {
            BDDNewFeatureCommand command =
                new BDDNewFeatureCommand(this);
            command.Execute();
        }
    }
}
