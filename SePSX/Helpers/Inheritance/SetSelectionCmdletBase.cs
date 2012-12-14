/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2012-08-02
 * Time: 00:05
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX
{
    using System;
    using System.Management.Automation;
    using OpenQA.Selenium;
    
    /// <summary>
    /// Description of SelectCmdletBase.
    /// </summary>
    public class SetSelectionCmdletBase : HasWebElementInputCmdletBase
    {
        public SetSelectionCmdletBase()
        {
        }
        
        #region Parameters
        [Parameter(Mandatory = true,
                   ParameterSetName = "ByIndex")]
        [ValidateRange(0, 10000000)]
        public int[] Index { get; set; }
        
        [Parameter(Mandatory = true,
                   ParameterSetName = "ByValue")]
        [ValidateNotNullOrEmpty()]
        public string[] Value { get; set; }
        
        [Parameter(Mandatory = true,
                   ParameterSetName = "ByVisibleText")]
        [ValidateNotNullOrEmpty()]
        public string[] VisibleText { get; set; }
        
        [Parameter(Mandatory = true,
                   ParameterSetName = "All")]
        public SwitchParameter All { get; set; }
        
        [Parameter(Mandatory = false)]
        public SwitchParameter Deselect { get; set; }
        
        [Parameter(Mandatory = false, 
                   ValueFromPipeline = true)] //,
            //Position = 0,
            //HelpMessage = "This is usually the output from Start-Se[Driver] or Get-SeWebElement" )] 
        public new IWebElement[] InputObject { get; set; } // virtual ??
        #endregion Parameters
        
//        protected void SelectByIndex(int index)
//        {
//            
//        }
    }
}
