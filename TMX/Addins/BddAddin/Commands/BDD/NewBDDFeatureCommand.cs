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
    /// Description of NewBddFeatureCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "BddFeature")]
    public class NewBddFeatureCommand : BddFeatureCmdletBase
    {
        protected override void BeginProcessing()
        {
            var command = new BddNewFeatureCommand(this);
            command.Execute();
        }
    }
}
