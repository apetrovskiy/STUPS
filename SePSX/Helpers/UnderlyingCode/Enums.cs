/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 09.08.2012
 * Time: 20:58
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX
{
    /// <summary>
    /// Used for determining what type (WebDriver or WebElement)
    /// of source search was performed against.
    /// </summary>
    internal enum WebElementsFrom
    {
        WebDriver,
        WebElement
    }
    
    // 20121206
    //public enum FindElementParameters
    internal enum FindElementParameters
    {
        ById,
        ByClassName,
        ByTagName,
        ByName,
        ByLinkText,
        ByPartialLinkText,
        ByCSS,
        ByXPath,
        ByJavaScript//,
        //All
    }
    
    // // 20121206
    public enum Drivers {
    //internal enum Drivers {
        Chrome,
        Firefox,
        InternetExplorer,
        Safari,
//        Opera,
        HTML //,
//        iOS,
//        Android
    }
    
    // 20121206
    //public enum InternetExplorer {
    internal enum InternetExplorer {
        x86,
        x64
    }
    
    public enum RecorderLanguages {
        PowerShell,
        CSharp,
        Java
    }
    
	internal enum DriverServers
	{
	    none,
	    chrome,
	    ie
	}
	
	internal enum DriverServerConstructorOptions
	{
		bare,
		with_path,
		with_options,
		with_path_and_options,
		with_path_and_options_and_timespan,
		with_service_and_options_and_timespan
	}

//	internal enum ChromeDriverConstructorOptions
//	{
//		chrome_bare,
//		chrome_with_path,
//		chrome_with_options,
//		chrome_with_path_and_options,
//		chrome_with_path_and_options_and_timespan,
//		chrome_with_service_and_options_and_timespan
//	}
//	
//	internal enum IEDriverConstructorOptions
//	{
//		ie_bare,
//		ie_with_path,
//		ie_with_options,
//		ie_with_path_and_options,
//		ie_with_path_and_options_and_timespan,
//		ie_with_service_and_options_and_timespan
//	}
	
	internal enum FirefoxProfileConstructorOptions
	{
		ff_bare,
		ff_with_path,
		ff_with_path_and_bool
	}

            //bare
            //FirefoxProfile profile
            //ICapabilities capabilities
            //FirefoxBinary binary, FirefoxProfile profile
            //FirefoxBinary binary, FirefoxProfile profile, TimeSpan commandTimeout
            
	internal enum FirefoxDriverConstructorOptions
	{
		ff_bare,
		ff_with_profile,
		ff_with_capabilities,
		ff_with_binary_and_profile,
		ff_with_binary_and_profile_and_timeout
	}
    
	// // 20121206
    public enum DriverTimeoutTypes {
    //internal enum DriverTimeoutTypes {
        ImplicitlyWait,
        PageLoad,
        Script
    }
    
	// // 20121206
    public enum SwitchToFrameWays {
    //internal enum SwitchToFrameWays {
        FrameIndex,
        FrameName,
        FrameElement
    }
	
	internal enum Constructors {
	    FakeWebElement_NoParameters,
	    FakeWebElement_IWebDriver,
	    FakeWebElement_TagName_Text,
        FakeWebElement_TagName_Text_Displayed_Enabled_Selected,
        FakeWebElement_TagName_Text_Location_Size,
        FakeWebElement_As_Decorator
	}
}