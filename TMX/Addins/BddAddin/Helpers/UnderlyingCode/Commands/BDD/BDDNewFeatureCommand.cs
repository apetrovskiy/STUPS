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
    /// Description of BddNewFeatureCommand.
    /// </summary>
    class BddNewFeatureCommand : BddCommand
    {
        internal BddNewFeatureCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            var cmdlet = (BddFeatureCmdletBase)Cmdlet;
            BDDHelper.CreateNewFeature(cmdlet);
        }
    }
}
