/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 4/1/2013
 * Time: 3:49 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
    using Interfaces;
    using Commands;
    
    /// <summary>
    /// Description of TmxGetTestResultDetailsCommand.
    /// </summary>
    class TmxGetTestResultDetailsCommand : TmxCommand
    {
        internal TmxGetTestResultDetailsCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            var cmdlet = (GetTmxTestResultDetailsCommand)Cmdlet;
            
            // 20140721
            var dataObject = new TestResultStatusCmdletBaseDataObject {
                TestOrigin = cmdlet.TestOrigin,
                TestResultStatus = cmdlet.TestResultStatus,
                Id = cmdlet.Id
            };
            
            // TmxHelper.GetTestResultDetails(cmdlet);
            TmxHelper.GetTestResultDetails(dataObject);
        }
    }
}
