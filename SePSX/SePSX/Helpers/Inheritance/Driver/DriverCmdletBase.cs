/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/18/2012
 * Time: 8:14 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX
{
    using System.Management.Automation;
    
    /// <summary>
    /// Description of DriverCmdletBase.
    /// </summary>
    public class DriverCmdletBase : CommonCmdletBase
    {
        
#region commented
//        protected const string driverNameFirefox = "FIREFOX";
//        protected const string driverNameFirefox2 = "FF";
//        protected const string driverNameChrome = "CHROME";
//        protected const string driverNameChrome2 = "CH";
//        protected const string driverNameInternetExplorer = "INTERNETEXPLORER";
//        protected const string driverNameInternetExplorer2 = "IE";
//        protected const string driverNameSafari = "SAFARI";
//        protected const string driverNameSafari2 = "SF";
//        protected const string driverNameOpera = "OPERA";
//        protected const string driverNameOpera2 = "OP";
//        protected const string driverNameAndroid = "ANDROID";
//        protected const string driverNameAndroid2 = "AN";
//        protected const string driverNameHTMLUnit = "HTMLUNIT";
//        protected const string driverNameHTMLUnit2 = "HTML";
#endregion commented

        public DriverCmdletBase()
        {
        }
        
        #region Parameters
        [Parameter(Mandatory = false,
                   ParameterSetName = "ByName")]
        [Parameter(Mandatory = false,
                   ParameterSetName = "ChromeDriver")]
        [Parameter(Mandatory = false,
                   ParameterSetName = "IEDriver")]
        [Parameter(Mandatory = false,
                   ParameterSetName = "Independent")]
        public string[] InstanceName { get; set; }
        #endregion Parameters
    }
}
