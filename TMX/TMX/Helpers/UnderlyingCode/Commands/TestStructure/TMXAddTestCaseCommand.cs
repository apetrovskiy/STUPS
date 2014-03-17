/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/20/2012
 * Time: 1:39 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
    using System;
    using System.Management.Automation;
    using PSTestLib;
    
    /// <summary>
    /// Description of TmxAddTestCaseCommand.
    /// </summary>
    internal class TmxAddTestCaseCommand : AbstractCommand // : TmxCommand
    {
        internal TmxAddTestCaseCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        // internal override void Execute()
        public override void Execute()
        {
            var cmdlet =
                (AddTestCaseCmdletBase)this.Cmdlet;
            
            bool result = 
                TMX.TmxHelper.AddTestCase(cmdlet);
            
            // 20130616
            TMX.Logger.TmxLogger.Info("Test case: '" + cmdlet.Name + "'");
            
            if (result) {
                
                cmdlet.WriteObject(
                    cmdlet,
                    TestData.CurrentTestCase);
            } else {
                cmdlet.WriteError(
                    cmdlet,
                    "Couldn't add a test case",
                    "AddingTestCase",
                    ErrorCategory.InvalidArgument,
                    true);
            }
        }
    }
}
