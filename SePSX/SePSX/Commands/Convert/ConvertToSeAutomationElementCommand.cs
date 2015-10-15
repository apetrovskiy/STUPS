/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 8/16/2012
 * Time: 1:18 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX.Commands
{
    using System.Management.Automation;

    /// <summary>
    /// Description of ConvertToSeAutomationElementCommand.
    /// </summary>
    [Cmdlet(VerbsData.ConvertTo, "SeAutomationElement")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement))]
    public class ConvertToSeAutomationElementCommand : ConvertCmdletBase
    {
        public ConvertToSeAutomationElementCommand()
        {
        }
        
        protected override void ProcessRecord()
        {
            CheckInputWebDriverOrWebElement();
            
            WriteVerbose(this, "the input is checked and valid");
            
            //SeHelper.ConvertWebDriverToAutomationElement(this, ((IWebDriver[])this.InputObject));
            SeHelper.ConvertWebDriverOrWebElementToAutomationElement(this, (InputObject));
        }
    }
}
