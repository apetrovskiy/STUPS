/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2012-08-02
 * Time: 00:01
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX.Commands
{
    using System.Management.Automation;
    using OpenQA.Selenium;
    
    /// <summary>
    /// Description of GetSeSelectionCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeSelection")]
    [OutputType(typeof(IWebElement))]
    public class GetSeSelectionCommand : GetSelectionCmdletBase
    {
        public GetSeSelectionCommand()
        {
        }
        
        protected override void ProcessRecord()
        {
            checkInputWebElementOnly(InputObject);
            
            SeHelper.GetSelect(
                this,
                InputObject,
                FirstSelected,
                Selected,
                All);
        }
    }
}
