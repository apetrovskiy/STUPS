/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/27/2012
 * Time: 3:57 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX
{
    using System;
    using System.Management.Automation;
    using SePSX.Commands;
    using Autofac;
    
    /// <summary>
    /// Description of SeStartWebDriverCommand.
    /// </summary>
    internal class SeStartWebDriverCommand : SeWebDriverCommand
    {
        internal SeStartWebDriverCommand(CommonCmdletBase cmdlet) : base(cmdlet)
        {
        }
        
        // internal override void Execute()
        public override void Execute()
        {
            SeHelper.StartWebDriver((StartSeWebDriverCommand)this.Cmdlet);

#region commented
            // ??
//            switch (((StartSeWebDriverCommand)this.Cmdlet).DriverName.ToUpper()) { //cmdlet.DriverName.ToUpper()
//                case SeHelper.driverNameChrome:
//                case SeHelper.driverNameChrome2:
//                    StartSeDriverServerCommand cmdletChrome =
//                        WebDriverFactory.Container.Resolve<StartSeDriverServerCommand>();
//                    cmdletChrome.InstanceName =
//                        ((StartSeWebDriverCommand)this.Cmdlet).InstanceName;
//                    cmdletChrome.AsService = true;
//                    cmdletChrome.DriverName = SeHelper.driverNameChrome;
//                    SeHelper.StartWebDriver(cmdletChrome);
//                    break;
//                case SeHelper.driverNameInternetExplorer:
//                case SeHelper.driverNameInternetExplorer2:
//                    StartSeDriverServerCommand cmdletIE =
//                        WebDriverFactory.Container.Resolve<StartSeDriverServerCommand>();
//                    cmdletIE.InstanceName =
//                        ((StartSeWebDriverCommand)this.Cmdlet).InstanceName;
//                    cmdletIE.AsService = true;
//                    cmdletIE.DriverName = SeHelper.driverNameInternetExplorer2;
//                    SeHelper.StartWebDriver(cmdletIE);
//                    break;
//                case SeHelper.driverNameFirefox:
//                case SeHelper.driverNameFirefox2:
//                    SeHelper.StartWebDriver((StartSeWebDriverCommand)this.Cmdlet); // ??
//                    break;
//                default:
//                    
//                	break;
//            }
            //SeHelper.StartWebDriver((StartSeDriverServerCommand)this.Cmdlet); // ??
#endregion commented
        }
    }
}
