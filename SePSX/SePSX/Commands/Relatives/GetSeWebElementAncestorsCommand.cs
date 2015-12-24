/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10.08.2012
 * Time: 6:34
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX.Commands
{
    using System.Management.Automation;
    using OpenQA.Selenium;
    
    /// <summary>
    /// Description of GetSeWebElementAncestorsCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeWebElementAncestors")]
    public class GetSeWebElementAncestorsCommand : WebElementCmdletBase
    {
        public GetSeWebElementAncestorsCommand()
        {
        }
        
        protected override void ProcessRecord()
        {
            checkInputWebElementOnly(InputObject);
            
            SeHelper.GetElementAncestors(this, ((IWebElement[])InputObject));
        }
    }
}
