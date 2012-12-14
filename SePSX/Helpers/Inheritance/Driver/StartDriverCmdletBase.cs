/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/28/2012
 * Time: 9:13 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX
{
    using System;
    using System.Management.Automation;
    //using OpenQA.Selenium;
    
    /// <summary>
    /// Description of StartDriverCmdletBase.
    /// </summary>
    public class StartDriverCmdletBase : DriverCmdletBase
    {
        public StartDriverCmdletBase()
        {
            this.Count = 0;
        }
        
        #region Parameters

#region commented
        //[Parameter(Mandatory = false)]
//        [Parameter(Mandatory = false,
//                   ParameterSetName = "ChromeDriver")]
//        [Parameter(Mandatory = false,
//                   ParameterSetName = "IEDriver")]
#endregion commented

        [Parameter(Mandatory = false,
                   ParameterSetName = "Independent")]
        [ValidateNotNullOrEmpty()]
        public string DriverName { get; set; }
        
//        [Parameter(Mandatory = false)]
//        public string[] InstanceName { get; set; }
        
        [Parameter(Mandatory = false)]
        public int Count { get; set; }
        #endregion Parameters
        
        internal InternetExplorer Architecture { get; set; }
        
        protected override void BeginProcessing()
        {
            this.CheckParameters();
            
            SeHelper.SetBrowserInstanceForeground(this);
        }
    }
}
