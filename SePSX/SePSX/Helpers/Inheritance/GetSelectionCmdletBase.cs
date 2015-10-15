/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2012-08-02
 * Time: 00:06
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX
{
    using System.Management.Automation;
    using OpenQA.Selenium;
    
    /// <summary>
    /// Description of GetSelectedCmdletBase.
    /// </summary>
    public class GetSelectionCmdletBase : HasWebElementInputCmdletBase
    {
        public GetSelectionCmdletBase()
        {
        }
        
        #region Parameters
        [Parameter(Mandatory = true,
                   ParameterSetName = "First")]
        public SwitchParameter FirstSelected { get; set; }
        
        [Parameter(Mandatory = true,
                   ParameterSetName = "Selected")]
        public SwitchParameter Selected { get; set; }
        
        [Parameter(Mandatory = true,
                   ParameterSetName = "All")]
        public SwitchParameter All { get; set; }
        
        [Parameter(Mandatory = false, 
                   ValueFromPipeline = true)] //,
            //Position = 0,
            //HelpMessage = "This is usually the output from Start-Se[Driver] or Get-SeWebElement" )] 
        public new IWebElement[] InputObject { get; set; } // virtual ??
        #endregion Parameters
    }
}
