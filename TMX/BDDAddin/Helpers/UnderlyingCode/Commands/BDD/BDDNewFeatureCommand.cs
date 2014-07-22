/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/18/2012
 * Time: 5:25 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of BDDNewFeatureCommand.
    /// </summary>
    internal class BDDNewFeatureCommand : BDDCommand
    {
        internal BDDNewFeatureCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            var cmdlet = (BDDFeatureCmdletBase)Cmdlet;
            BDDHelper.CreateNewFeature(cmdlet);
        }
    }
}
