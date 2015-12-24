/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/22/2012
 * Time: 11:59 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Remote;
    
    /// <summary>
    /// Description of CapabilitiesFactory.
    /// </summary>
    public static class CapabilitiesFactory
    {
//        public CapabilitiesFactory()
//        {
//        }
        
        public static ICapabilities GetCapabilities()
        {
            ICapabilities cap = new DesiredCapabilities();
            
            
            return cap;
        }
    }
}
